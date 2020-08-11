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
    public class PlanoProcedimentoEmpresaController : Controller
    {
        private readonly DBJennContext _context;

        public PlanoProcedimentoEmpresaController(DBJennContext context)
        {
            _context = context;
        }

        // GET: PlanoProcedimentoEmpresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanoProcedimentoEmpresas.ToListAsync());
        }

        // GET: PlanoProcedimentoEmpresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoProcedimentoEmpresa = await _context.PlanoProcedimentoEmpresas
                .FirstOrDefaultAsync(m => m.PlanoProcedimentoEmpresaID == id);
            if (planoProcedimentoEmpresa == null)
            {
                return NotFound();
            }

            return View(planoProcedimentoEmpresa);
        }

        // GET: PlanoProcedimentoEmpresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanoProcedimentoEmpresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanoProcedimentoEmpresaID")] PlanoProcedimentoEmpresa planoProcedimentoEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planoProcedimentoEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planoProcedimentoEmpresa);
        }

        // GET: PlanoProcedimentoEmpresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoProcedimentoEmpresa = await _context.PlanoProcedimentoEmpresas.FindAsync(id);
            if (planoProcedimentoEmpresa == null)
            {
                return NotFound();
            }
            return View(planoProcedimentoEmpresa);
        }

        // POST: PlanoProcedimentoEmpresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanoProcedimentoEmpresaID")] PlanoProcedimentoEmpresa planoProcedimentoEmpresa)
        {
            if (id != planoProcedimentoEmpresa.PlanoProcedimentoEmpresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planoProcedimentoEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoProcedimentoEmpresaExists(planoProcedimentoEmpresa.PlanoProcedimentoEmpresaID))
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
            return View(planoProcedimentoEmpresa);
        }

        // GET: PlanoProcedimentoEmpresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoProcedimentoEmpresa = await _context.PlanoProcedimentoEmpresas
                .FirstOrDefaultAsync(m => m.PlanoProcedimentoEmpresaID == id);
            if (planoProcedimentoEmpresa == null)
            {
                return NotFound();
            }

            return View(planoProcedimentoEmpresa);
        }

        // POST: PlanoProcedimentoEmpresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planoProcedimentoEmpresa = await _context.PlanoProcedimentoEmpresas.FindAsync(id);
            _context.PlanoProcedimentoEmpresas.Remove(planoProcedimentoEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoProcedimentoEmpresaExists(int id)
        {
            return _context.PlanoProcedimentoEmpresas.Any(e => e.PlanoProcedimentoEmpresaID == id);
        }
    }
}
