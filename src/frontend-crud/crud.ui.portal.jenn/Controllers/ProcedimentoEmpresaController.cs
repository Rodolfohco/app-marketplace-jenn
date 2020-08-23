using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.portal.jenn.Contexto;
using api.portal.jenn.DTO;
using crud.ui.portal.jenn.Enumeradores;
using System.Data;
using database.portal.jenn.DTO.api.portal.jenn.DTO;

namespace crud.ui.portal.jenn.Controllers
{
    public class ProcedimentoEmpresaController : Controller
    {
        private readonly DBJennContext _context;

        public ProcedimentoEmpresaController(DBJennContext context)
        {
            _context = context;
        }

        // GET: ProcedimentoEmpresa
        public async Task<IActionResult> Index()
        {
            var dBJennContext = _context.ProcedimentoEmpresa.Include(p => p.Empresa).Include(p => p.Procedimento).ThenInclude(x=> x.TipoProcedimento);
            return View(await dBJennContext.ToListAsync());
        }

        // GET: ProcedimentoEmpresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimentoEmpresa = await _context.ProcedimentoEmpresa
                .Include(p => p.Empresa)
                .Include(p => p.Procedimento)
                .FirstOrDefaultAsync(m => m.ProcedimentoEmpresaID == id);
            if (procedimentoEmpresa == null)
            {
                return NotFound();
            }

            return View(procedimentoEmpresa);
        }

        // GET: ProcedimentoEmpresa/Create
        public IActionResult Create()
        {
            GetCombo();
            return View();
        }

        public async Task<IActionResult> Desativar(int id)
        {
            var procedimento = _context.ProcedimentoEmpresa.Find(id);


            if (procedimento.Ativo == 1)
            {
                procedimento.Ativo = 0;
            }
            else
            {
                procedimento.Ativo = 1;
            }



            _context.Update(procedimento);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public  void GetCombo()
        {

         



            ViewData["TipoProcedimentoID"] = new SelectList(_context.TipoProcedimento.AsEnumerable(), "TipoProcedimentoID", "Nome");
            ViewData["EmpresaID"] = new SelectList(_context.Empresas.Where(c=> c.Ativo > 0).AsEnumerable(), "EmpresaID", "Nome");
            ViewData["ProcedimentoID"] = new SelectList(_context.Procedimento.Where(x => x.Ativo > 0).ToList(), "ProcedimentoID", "Nome");
        }

        // POST: ProcedimentoEmpresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcedimentoEmpresa procedimentoEmpresa, int TipoProcedimentoID)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(procedimentoEmpresa.ImagemHome))
                    procedimentoEmpresa.ImagemHome = string.Empty;


                if (string.IsNullOrEmpty(procedimentoEmpresa.ImagemMain))
                    procedimentoEmpresa.ImagemMain = string.Empty;


                if (string.IsNullOrEmpty(procedimentoEmpresa.ImagemThumb))
                    procedimentoEmpresa.ImagemThumb = string.Empty;

                if (string.IsNullOrEmpty(procedimentoEmpresa.Video))
                    procedimentoEmpresa.Video = string.Empty;


                if (string.IsNullOrEmpty(procedimentoEmpresa.TaxaParcelamento))
                    procedimentoEmpresa.TaxaParcelamento = string.Empty;


                if (string.IsNullOrEmpty(procedimentoEmpresa.TaxaResultado))
                    procedimentoEmpresa.TaxaResultado = string.Empty;


                procedimentoEmpresa.Ativo = (int) Status.Desativado;

                procedimentoEmpresa.DataInclusao = DateTime.Now;


                var tipo = _context.TipoProcedimento.Find(TipoProcedimentoID);


                var procedimentos = _context.Procedimento.Where(c => c.TipoProcedimento.TipoProcedimentoID == tipo.TipoProcedimentoID).ToList();
         
                procedimentos.ForEach(proced =>
                {
                    var consulta = _context.ProcedimentoEmpresa.Where(x => x.ProcedimentoID == proced.ProcedimentoID && x.EmpresaID == procedimentoEmpresa.EmpresaID).FirstOrDefault();

                    if (consulta == null)
                    {
                        ProcedimentoEmpresa procedimentoEmp = new ProcedimentoEmpresa();
                        procedimentoEmp = procedimentoEmpresa;
                        procedimentoEmp.ProcedimentoEmpresaID = 0;
                        procedimentoEmp.Procedimento = proced;

                        procedimentoEmp.Nome_pers = proced.Nome;




                        _context.ProcedimentoEmpresa.Add(procedimentoEmp);
                        _context.SaveChanges();
                    }
                });



                return RedirectToAction(nameof(Index));
            }
            GetCombo();
            return View(procedimentoEmpresa);
        }

        // GET: ProcedimentoEmpresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimentoEmpresa = await _context.ProcedimentoEmpresa.FindAsync(id);
            if (procedimentoEmpresa == null)
            {
                return NotFound();
            }

            ViewData["EmpresaID"] = new SelectList(_context.Empresas.Where(c => c.MatrizID.HasValue && c.Ativo > 0).AsEnumerable(), "EmpresaID", "Nome", procedimentoEmpresa.EmpresaID);

            ViewData["ProcedimentoID"] = new SelectList(_context.Procedimento.Where(x => x.Ativo > 0).ToList(), "ProcedimentoID", "Nome", procedimentoEmpresa.ProcedimentoID);


                  return View(procedimentoEmpresa);
        }

        // POST: ProcedimentoEmpresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  ProcedimentoEmpresa procedimentoEmpresa)
        {
            if (id != procedimentoEmpresa.ProcedimentoEmpresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(procedimentoEmpresa.ImagemHome))
                        procedimentoEmpresa.ImagemHome = string.Empty;


                    if (string.IsNullOrEmpty(procedimentoEmpresa.ImagemMain))
                        procedimentoEmpresa.ImagemMain = string.Empty;


                    if (string.IsNullOrEmpty(procedimentoEmpresa.ImagemThumb))
                        procedimentoEmpresa.ImagemThumb = string.Empty;

                    if (string.IsNullOrEmpty(procedimentoEmpresa.Video))
                        procedimentoEmpresa.Video = string.Empty;



                    _context.Entry(procedimentoEmpresa).State = EntityState.Modified;

                    _context.Update(procedimentoEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimentoEmpresaExists(procedimentoEmpresa.ProcedimentoEmpresaID))
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas.Where(c => c.MatrizID.HasValue && c.Ativo > 0).AsEnumerable(), "EmpresaID", "Nome", procedimentoEmpresa.EmpresaID);

            ViewData["ProcedimentoID"] = new SelectList(_context.Procedimento.Where(x => x.Ativo > 0).ToList(), "ProcedimentoID", "Nome", procedimentoEmpresa.ProcedimentoID);
            return View(procedimentoEmpresa);
        }

        // GET: ProcedimentoEmpresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimentoEmpresa = await _context.ProcedimentoEmpresa
                .Include(p => p.Empresa)
                .Include(p => p.Procedimento)
                .FirstOrDefaultAsync(m => m.ProcedimentoEmpresaID == id);
            if (procedimentoEmpresa == null)
            {
                return NotFound();
            }

            return View(procedimentoEmpresa);
        }

        // POST: ProcedimentoEmpresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedimentoEmpresa = await _context.ProcedimentoEmpresa.FindAsync(id);
            _context.ProcedimentoEmpresa.Remove(procedimentoEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentoEmpresaExists(int id)
        {
            return _context.ProcedimentoEmpresa.Any(e => e.ProcedimentoEmpresaID == id);
        }
    }
}
