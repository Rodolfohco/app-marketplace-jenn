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
    public class PagamentoProcedimentoEmpresaController : Controller
    {
        private readonly DBJennContext _context;

        public PagamentoProcedimentoEmpresaController(DBJennContext context)
        {
            _context = context;
        }

        // GET: PagamentoProcedimentoEmpresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.PagamentoProcedimentoEmpresa.ToListAsync());
        }

        // GET: PagamentoProcedimentoEmpresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoProcedimentoEmpresa = await _context.PagamentoProcedimentoEmpresa
                .FirstOrDefaultAsync(m => m.PagamentoProcedimentoEmpresaID == id);
            if (pagamentoProcedimentoEmpresa == null)
            {
                return NotFound();
            }

            return View(pagamentoProcedimentoEmpresa);
        }

        // GET: PagamentoProcedimentoEmpresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagamentoProcedimentoEmpresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoProcedimentoEmpresaID")] PagamentoProcedimentoEmpresa pagamentoProcedimentoEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoProcedimentoEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagamentoProcedimentoEmpresa);
        }

        // GET: PagamentoProcedimentoEmpresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoProcedimentoEmpresa = await _context.PagamentoProcedimentoEmpresa.FindAsync(id);
            if (pagamentoProcedimentoEmpresa == null)
            {
                return NotFound();
            }
            return View(pagamentoProcedimentoEmpresa);
        }

        // POST: PagamentoProcedimentoEmpresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoProcedimentoEmpresaID")] PagamentoProcedimentoEmpresa pagamentoProcedimentoEmpresa)
        {
            if (id != pagamentoProcedimentoEmpresa.PagamentoProcedimentoEmpresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoProcedimentoEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoProcedimentoEmpresaExists(pagamentoProcedimentoEmpresa.PagamentoProcedimentoEmpresaID))
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
            return View(pagamentoProcedimentoEmpresa);
        }

        // GET: PagamentoProcedimentoEmpresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoProcedimentoEmpresa = await _context.PagamentoProcedimentoEmpresa
                .FirstOrDefaultAsync(m => m.PagamentoProcedimentoEmpresaID == id);
            if (pagamentoProcedimentoEmpresa == null)
            {
                return NotFound();
            }

            return View(pagamentoProcedimentoEmpresa);
        }

        // POST: PagamentoProcedimentoEmpresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentoProcedimentoEmpresa = await _context.PagamentoProcedimentoEmpresa.FindAsync(id);
            _context.PagamentoProcedimentoEmpresa.Remove(pagamentoProcedimentoEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoProcedimentoEmpresaExists(int id)
        {
            return _context.PagamentoProcedimentoEmpresa.Any(e => e.PagamentoProcedimentoEmpresaID == id);
        }
    }
}
