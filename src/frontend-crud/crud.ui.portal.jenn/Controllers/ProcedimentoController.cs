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

namespace crud.ui.portal.jenn.Controllers
{
    public class ProcedimentoController : Controller
    {
        private readonly DBJennContext _context;

        public ProcedimentoController(DBJennContext context)
        {
            _context = context;
        }

        // GET: Procedimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procedimento.ToListAsync());
        }

        // GET: Procedimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimento
                .FirstOrDefaultAsync(m => m.ProcedimentoID == id);
            if (procedimento == null)
            {
                return NotFound();
            }

            return View(procedimento);
        }

        // GET: Procedimento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procedimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcedimentoID,Nome,Descricao,ImgProduto,Ativo")] Procedimento procedimento)
        {
            if (ModelState.IsValid)
            {
                procedimento.Ativo =(int)Status.Ativo;
                


                _context.Add(procedimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedimento);
        }

        // GET: Procedimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimento.FindAsync(id);
            if (procedimento == null)
            {
                return NotFound();
            }
            return View(procedimento);
        }

        // POST: Procedimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcedimentoID,Nome,Descricao,ImgProduto,Ativo")] Procedimento procedimento)
        {
            if (id != procedimento.ProcedimentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimentoExists(procedimento.ProcedimentoID))
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
            return View(procedimento);
        }

        // GET: Procedimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimento = await _context.Procedimento
                .FirstOrDefaultAsync(m => m.ProcedimentoID == id);
            if (procedimento == null)
            {
                return NotFound();
            }

            return View(procedimento);
        }

        // POST: Procedimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procedimento = await _context.Procedimento.FindAsync(id);
            _context.Procedimento.Remove(procedimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentoExists(int id)
        {
            return _context.Procedimento.Any(e => e.ProcedimentoID == id);
        }
    }
}
