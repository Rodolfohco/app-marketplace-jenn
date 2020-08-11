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
    public class CategoriaProcedimentoController : Controller
    {
        private readonly DBJennContext _context;

        public CategoriaProcedimentoController(DBJennContext context)
        {
            _context = context;
        }

        // GET: CategoriaProcedimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaProced.ToListAsync());
        }

        // GET: CategoriaProcedimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProcedimento = await _context.CategoriaProced
                .FirstOrDefaultAsync(m => m.CategoriaID == id);
            if (categoriaProcedimento == null)
            {
                return NotFound();
            }

            return View(categoriaProcedimento);
        }

        // GET: CategoriaProcedimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProcedimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaID,Nome")] CategoriaProcedimento categoriaProcedimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaProcedimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProcedimento);
        }

        // GET: CategoriaProcedimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProcedimento = await _context.CategoriaProced.FindAsync(id);
            if (categoriaProcedimento == null)
            {
                return NotFound();
            }
            return View(categoriaProcedimento);
        }

        // POST: CategoriaProcedimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaID,Nome")] CategoriaProcedimento categoriaProcedimento)
        {
            if (id != categoriaProcedimento.CategoriaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProcedimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProcedimentoExists(categoriaProcedimento.CategoriaID))
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
            return View(categoriaProcedimento);
        }

        // GET: CategoriaProcedimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProcedimento = await _context.CategoriaProced
                .FirstOrDefaultAsync(m => m.CategoriaID == id);
            if (categoriaProcedimento == null)
            {
                return NotFound();
            }

            return View(categoriaProcedimento);
        }

        // POST: CategoriaProcedimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaProcedimento = await _context.CategoriaProced.FindAsync(id);
            _context.CategoriaProced.Remove(categoriaProcedimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProcedimentoExists(int id)
        {
            return _context.CategoriaProced.Any(e => e.CategoriaID == id);
        }
    }
}
