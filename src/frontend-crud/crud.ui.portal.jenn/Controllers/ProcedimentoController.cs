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
using database.portal.jenn.DTO.api.portal.jenn.DTO;

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
            return View(await _context.Procedimento.Include(x=> x.TipoProcedimento).ToListAsync());
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
        private void GetTipo(bool Selecionar = true)
        {
            List<SelectListItem> item = _context.TipoProcedimento
                .Select(c => new SelectListItem() { Text = c.Nome, Value = c.TipoProcedimentoID.ToString() }).ToList();


            if (Selecionar)
            {
                if (item.Count > 0)
                    item.Insert(0, new SelectListItem() { Text = "Selecione Uma Opção", Value = "", Selected = true });
                else
                    item.Insert(0, new SelectListItem() { Text = "Não Existem  Cadastradas", Value = "", Selected = true });
            }

            ViewBag.TipoProcedimento = item;
        }
        // GET: Procedimento/Create
        public IActionResult Create()
        {
            GetTipo();
            return View();
        }

        // POST: Procedimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcedimentoID,Nome,Descricao,ImgProduto_Proc,Ativo")] Procedimento procedimento, int TipoProcedimento)
        {
            if (ModelState.IsValid)
            {
                procedimento.Ativo =(int)Status.Ativo;
                procedimento.TipoProcedimento = _context.TipoProcedimento.Find(TipoProcedimento);


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

            //      var procedimento = await _context.Procedimento.FindAsync(id);
            var procedimento = await (from item in _context.Procedimento.Include(c => c.TipoProcedimento)
                                where item.ProcedimentoID == id
                                select item).FirstOrDefaultAsync();


            if (procedimento == null)
            {
                return NotFound();
            }
            GetTipo(false);
            return View(procedimento);
        }

        // POST: Procedimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcedimentoID,Nome,Descricao,ImgProduto_Proc,Ativo")] Procedimento procedimento)
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
