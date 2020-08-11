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
    public class EmpresaController : Controller
    {
        private readonly DBJennContext _context;

        public EmpresaController(DBJennContext context)
        {
            _context = context;
        }

        // GET: Empresa
        public async Task<IActionResult> Index()
        {
            var dBJennContext = _context.Empresas.Include(e => e.Matriz);
            return View(await dBJennContext.ToListAsync());
        }

        // GET: Empresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.Matriz)
                .FirstOrDefaultAsync(m => m.EmpresaID == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresa/Create
        public IActionResult Create()
        {
            ViewData["MatrizID"] = new SelectList(_context.Empresas, "EmpresaID", "Logradouro");
            return View();
        }

        // POST: Empresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCnes,EmpresaID,MatrizID,cnpj,Nome,Telefone1,Telefone2,ImgemFrontEmpresa,Email,Logradouro,numero,bairro,cep,maps,Responsavel,Id_classe,Cert_Empresa,Ativo")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatrizID"] = new SelectList(_context.Empresas, "EmpresaID", "Logradouro", empresa.MatrizID);
            return View(empresa);
        }

        // GET: Empresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["MatrizID"] = new SelectList(_context.Empresas, "EmpresaID", "Logradouro", empresa.MatrizID);
            return View(empresa);
        }

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCnes,EmpresaID,MatrizID,cnpj,Nome,Telefone1,Telefone2,ImgemFrontEmpresa,Email,Logradouro,numero,bairro,cep,maps,Responsavel,Id_classe,Cert_Empresa,Ativo")] Empresa empresa)
        {
            if (id != empresa.EmpresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.EmpresaID))
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
            ViewData["MatrizID"] = new SelectList(_context.Empresas, "EmpresaID", "Logradouro", empresa.MatrizID);
            return View(empresa);
        }

        // GET: Empresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.Matriz)
                .FirstOrDefaultAsync(m => m.EmpresaID == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.EmpresaID == id);
        }
    }
}
