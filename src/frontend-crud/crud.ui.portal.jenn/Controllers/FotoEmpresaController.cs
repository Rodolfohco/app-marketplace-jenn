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
    public class FotoEmpresaController : Controller
    {
        private readonly DBJennContext _context;

        public FotoEmpresaController(DBJennContext context)
        {
            _context = context;
        }

        // GET: FotoEmpresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.FotoEmpresas.ToListAsync());
        }

        // GET: FotoEmpresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotoEmpresa = await _context.FotoEmpresas
                .FirstOrDefaultAsync(m => m.FotoID == id);
            if (fotoEmpresa == null)
            {
                return NotFound();
            }

            return View(fotoEmpresa);
        }

        // GET: FotoEmpresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FotoEmpresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FotoID,path,Nome")] FotoEmpresa fotoEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotoEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fotoEmpresa);
        }

        // GET: FotoEmpresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotoEmpresa = await _context.FotoEmpresas.FindAsync(id);
            if (fotoEmpresa == null)
            {
                return NotFound();
            }
            return View(fotoEmpresa);
        }

        // POST: FotoEmpresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FotoID,path,Nome")] FotoEmpresa fotoEmpresa)
        {
            if (id != fotoEmpresa.FotoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotoEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotoEmpresaExists(fotoEmpresa.FotoID))
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
            return View(fotoEmpresa);
        }

        // GET: FotoEmpresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotoEmpresa = await _context.FotoEmpresas
                .FirstOrDefaultAsync(m => m.FotoID == id);
            if (fotoEmpresa == null)
            {
                return NotFound();
            }

            return View(fotoEmpresa);
        }

        // POST: FotoEmpresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotoEmpresa = await _context.FotoEmpresas.FindAsync(id);
            _context.FotoEmpresas.Remove(fotoEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoEmpresaExists(int id)
        {
            return _context.FotoEmpresas.Any(e => e.FotoID == id);
        }
    }
}
