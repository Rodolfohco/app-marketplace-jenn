using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.portal.jenn.Contexto;
using api.portal.jenn.DTO;

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
            var dBJennContext = _context.ProcedimentoEmpresa.Include(p => p.Empresa).Include(p => p.Procedimento);
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "Logradouro");
            ViewData["ProcedimentoID"] = new SelectList(_context.Procedimento, "ProcedimentoID", "Descricao");
            return View();
        }

        // POST: ProcedimentoEmpresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcedimentoEmpresaID,DataInclusao,Nome_pers,PrecoProduto,Preco_contra,TaxaParcelamento,TaxaResultado,ImagemThumb,ImagemHome,ImagemMain,Video,Ativo,Destaque,ProcedimentoID,EmpresaID")] ProcedimentoEmpresa procedimentoEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimentoEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "Logradouro", procedimentoEmpresa.EmpresaID);
            ViewData["ProcedimentoID"] = new SelectList(_context.Procedimento, "ProcedimentoID", "Descricao", procedimentoEmpresa.ProcedimentoID);
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "Logradouro", procedimentoEmpresa.EmpresaID);
            ViewData["ProcedimentoID"] = new SelectList(_context.Procedimento, "ProcedimentoID", "Descricao", procedimentoEmpresa.ProcedimentoID);
            return View(procedimentoEmpresa);
        }

        // POST: ProcedimentoEmpresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcedimentoEmpresaID,DataInclusao,Nome_pers,PrecoProduto,Preco_contra,TaxaParcelamento,TaxaResultado,ImagemThumb,ImagemHome,ImagemMain,Video,Ativo,Destaque,ProcedimentoID,EmpresaID")] ProcedimentoEmpresa procedimentoEmpresa)
        {
            if (id != procedimentoEmpresa.ProcedimentoEmpresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "Logradouro", procedimentoEmpresa.EmpresaID);
            ViewData["ProcedimentoID"] = new SelectList(_context.Procedimento, "ProcedimentoID", "Descricao", procedimentoEmpresa.ProcedimentoID);
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
