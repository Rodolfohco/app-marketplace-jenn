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
    public class TipoProcedimentoController : Controller
    {
        private readonly DBJennContext _context;

        public TipoProcedimentoController(DBJennContext context)
        {
            _context = context;
        }

        // GET: TipoProcedimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoProcedimento.Include(c=> c.Categoria).ToListAsync());
        }

        // GET: TipoProcedimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProcedimento = await _context.TipoProcedimento
                .FirstOrDefaultAsync(m => m.TipoProcedimentoID == id);
            if (tipoProcedimento == null)
            {
                return NotFound();
            }

            return View(tipoProcedimento);
        }

    


        // GET: TipoProcedimento/Create
        public IActionResult Create()
        {
            GetCategoria();

            return View();
        }

        private void GetCategoria(bool Selecionar=true)
        {
            List<SelectListItem> item = _context.CategoriaProced
                .Select(c => new SelectListItem() { Text = c.Nome, Value = c.CategoriaID.ToString() }).ToList();


            if (Selecionar)
            {
                if (item.Count > 0)
                    item.Insert(0, new SelectListItem() { Text = "Selecione Uma Opção", Value = "", Selected = true });
                else
                    item.Insert(0, new SelectListItem() { Text = "Não Existem Categorias Cadastradas", Value = "", Selected = true });
            }

            ViewBag.CategoriaProcedimento = item;
        }

        // POST: TipoProcedimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoProcedimentoID,Nome, Categoria")] TipoProcedimento tipoProcedimento, int Categoria)
        {
            if (ModelState.IsValid)
            {
                tipoProcedimento.Categoria = _context.CategoriaProced.Find(Categoria);

                _context.Add(tipoProcedimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProcedimento);
        }

        // GET: TipoProcedimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProcedimento = await (from consulta in _context.TipoProcedimento.Include(c => c.Categoria)
                            where consulta.TipoProcedimentoID == id
                            select consulta).FirstOrDefaultAsync();


            if (tipoProcedimento == null)
            {
                return NotFound();
            }

            GetCategoria(false);
            return View(tipoProcedimento);
        }

        // POST: TipoProcedimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoProcedimentoID,Nome")] TipoProcedimento tipoProcedimento)
        {
            if (id != tipoProcedimento.TipoProcedimentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProcedimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProcedimentoExists(tipoProcedimento.TipoProcedimentoID))
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
            return View(tipoProcedimento);
        }

        // GET: TipoProcedimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProcedimento = await _context.TipoProcedimento
                .FirstOrDefaultAsync(m => m.TipoProcedimentoID == id);
            if (tipoProcedimento == null)
            {
                return NotFound();
            }

            return View(tipoProcedimento);
        }

        // POST: TipoProcedimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoProcedimento = await _context.TipoProcedimento.FindAsync(id);
            _context.TipoProcedimento.Remove(tipoProcedimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProcedimentoExists(int id)
        {
            return _context.TipoProcedimento.Any(e => e.TipoProcedimentoID == id);
        }
    }
}
