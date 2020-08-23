using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.portal.jenn.Contexto;
using api.portal.jenn.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using crud.ui.portal.jenn.Enumeradores;
using database.portal.jenn.DTO.api.portal.jenn.DTO;
using System.Security.Cryptography.X509Certificates;

namespace crud.ui.portal.jenn.Controllers
{
    public class ConvenioController : Controller
    {
        private readonly DBJennContext _context;

        public ConvenioController(DBJennContext context)
        {
            _context = context;
        }

        // GET: Convenio
        public async Task<IActionResult> Index()
        {
            var convenio = _context.Convenios;

            return View(await convenio.ToListAsync()) ;
        }

        // GET: Convenio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenio = await _context.Convenios
                .FirstOrDefaultAsync(m => m.ConvenioId == id);
            if (convenio == null)
            {
                return NotFound();
            }

            return View(convenio);
        }

        // GET: Convenio/Create
        public IActionResult Create()
        {
            return View();
        }

        

        
    

        public async Task<IActionResult> Desativar(int id)
        {

            var empresa = await _context.Convenios
                .FirstOrDefaultAsync(m => m.ConvenioId == id);

            if (empresa.Ativo == database.portal.jenn.DTO.api.portal.jenn.DTO.Status.Desativado)
                empresa.Ativo = database.portal.jenn.DTO.api.portal.jenn.DTO.Status.Ativo;
            else
                empresa.Ativo = database.portal.jenn.DTO.api.portal.jenn.DTO.Status.Desativado;

            _context.Convenios.Update(empresa);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }




        // POST: Convenio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConvenioId,Nome,DataInclusao,Ativo")] Convenio convenio)
        {
            if (ModelState.IsValid)
            {
                convenio.Ativo = Status.Ativo;
                convenio.DataInclusao = DateTime.Now;

                if (convenio.Planos == null)
                {
                    convenio.Planos = new List<Plano>();
                    convenio.Planos.Add(new Plano() { Nome = "Plano Padrão" });
                }

                _context.Add(convenio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(convenio);
        }

        // GET: Convenio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenio = await _context.Convenios.Include(c=> c.Planos).Where(c=> c.ConvenioId == id).FirstOrDefaultAsync();
            if (convenio == null)
            {
                return NotFound();
            }
            ViewBag.Convenio = convenio.Nome;
            ViewBag.ConvenioID = convenio.ConvenioId;

            return View(convenio);
        }

        // POST: Convenio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConvenioId,Nome,DataInclusao,Ativo")] Convenio convenio)
        {
            if (id != convenio.ConvenioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                { 
                    _context.Update(convenio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvenioExists(convenio.ConvenioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                finally
                {



                    if (convenio.Planos == null)
                    {
                        var consulta = _context.Convenios.Where(x => x.ConvenioId == convenio.ConvenioId).Include(x => x.Planos).FirstOrDefault();
                        if (consulta.Planos.Count() == 0)
                        {
                            convenio.Planos = new List<Plano>();
                            convenio.Planos.Add(new Plano() { Nome = "Plano Padrão" });
                            _context.Update(convenio);
                            await _context.SaveChangesAsync();
                        }
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            return View(convenio);
        }

        // GET: Convenio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenio = await _context.Convenios
                .FirstOrDefaultAsync(m => m.ConvenioId == id);
            if (convenio == null)
            {
                return NotFound();
            }

            return View(convenio);
        }

        // POST: Convenio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var convenio = await _context.Convenios.FindAsync(id);
            _context.Convenios.Remove(convenio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvenioExists(int id)
        {
            return _context.Convenios.Any(e => e.ConvenioId == id);
        }
    }
}
