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
            return View(await _context.Convenios.ToListAsync());
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

        

        
        public async Task<JsonResult> NovoPlano(int ConvenioID, Plano plano)
        {
            //if (ModelState.IsValid)
            //{
            //    convenio.Ativo = (int)Status.Ativo;
            //    convenio.DataInclusao = DateTime.Now;


            //    _context.Add(convenio);
            //    await _context.SaveChangesAsync();
            //   // return RedirectToAction(nameof(Index));
            //}
            return new JsonResult(ConvenioID);
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
                convenio.Ativo = (int)Status.Ativo;
                convenio.DataInclusao = DateTime.Now;


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

            var convenio = await _context.Convenios.FindAsync(id);
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
