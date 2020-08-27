using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api.portal.jenn.Contexto;
using api.portal.jenn.DTO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;
using crud.ui.portal.jenn.Enumeradores;
using database.portal.jenn.DTO.api.portal.jenn.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace crud.ui.portal.jenn.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly DBJennContext _context;
        private readonly IMemoryCache cache;

        public EmpresaController(DBJennContext context, IMemoryCache memoryCache)
        {
            _context = context;

            this.cache = memoryCache;

        }

 
        public async Task<IActionResult> Index(int? atualizar = null)
        {
            List<Empresa> retorno = new List<Empresa>();

            if (atualizar.HasValue  && atualizar.Value>0)
            {
                var dBJennContext = _context.Empresas;

                retorno = await dBJennContext.ToListAsync();

                this.cache.Remove("cache__empresa");
                this.cache.Set("cache__empresa", retorno);

            }

            if (!this.cache.TryGetValue("cache__empresa", out retorno))
            {
                var dBJennContext = _context.Empresas;

                retorno = await dBJennContext.ToListAsync();

                this.cache.Set("cache__empresa", retorno);
            }

            return View(retorno);



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
        public async Task<IActionResult> Desativar(int  id)
        {
           
            var empresa = await _context.Empresas
                .Include(e => e.Matriz)
                .FirstOrDefaultAsync(m => m.EmpresaID == id);

            if (empresa.Ativo ==  database.portal.jenn.DTO.api.portal.jenn.DTO.Status.Desativado)
                empresa.Ativo = database.portal.jenn.DTO.api.portal.jenn.DTO.Status.Ativo;
            else
                empresa.Ativo = database.portal.jenn.DTO.api.portal.jenn.DTO.Status.Desativado;

            _context.Empresas.Update(empresa);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        private void GetMatriz( int MatrizID, bool Selecionar = true)
        {
            //if(MatrizID >0)
            //    ViewBag.MatrizID = new SelectList(_context.Empresas.Where(c => c.MatrizID.HasValue && c.Ativo > 0).AsEnumerable(), "MatrizID", "Nome", MatrizID);
            //else
            //    ViewBag.MatrizID = new SelectList(_context.Empresas.Where(c => c.MatrizID.HasValue && c.Ativo > 0).AsEnumerable(), "MatrizID", "Nome");

            var DBMatriz = _context.Empresas.Include(e => e.Matriz);
         
            List<SelectListItem> itemMatriz = new List<SelectListItem>();
            (
                from emp in DBMatriz.Select(c => c.Matriz)
             where !emp.MatrizID.HasValue
             select emp).Distinct().ToList().ForEach(empresa =>
             {
                 if (empresa != null)
                 {
                     itemMatriz.Insert(0, new SelectListItem() { Text = empresa.Nome, Value = empresa.EmpresaID.ToString() });
                 }
             });

            itemMatriz.Insert(0, new SelectListItem() { Text = "Empresa Matriz", Value = "" });

            ViewBag.MatrizID = itemMatriz;

        }


        private void GetCombo(bool Selecionar = true)
        {
            var DBMatriz = _context.Empresas.Include(e => e.Matriz).Include(c=> c.Grupo);
            var DbUfs = _context.Ufs;

            List<SelectListItem> itemMatriz = new List<SelectListItem>();
            (from emp in DBMatriz.Select(c => c.Matriz)
             where !emp.MatrizID.HasValue
             select emp).Distinct().AsParallel().ForAll(empresa =>
             {
                 if (empresa != null)
                 {
                     itemMatriz.Insert(0, new SelectListItem() { Text = empresa.Nome, Value = empresa.EmpresaID.ToString() });
                 }
             });

            itemMatriz.Insert(0, new SelectListItem() { Text = "Empresa Matriz", Value = "" });


            if (Selecionar)
            {
                if (DBMatriz.ToList().Count > 0)
                    itemMatriz.Insert(1, new SelectListItem() { Text = "Selecione Uma Opção", Value = "", Selected = true });
                else
                    itemMatriz.Insert(1, new SelectListItem() { Text = "Não Existem Registro", Value = "", Selected = true });
            }

            ViewBag.MatrizID = itemMatriz;


            List<SelectListItem> itemCidade = new List<SelectListItem>();
        

            DbUfs.Include(x=> x.Cidades).ToList().ForEach(uf =>
            {

                var itemUf = new SelectListGroup() {  Name = uf.Nome  };

                uf.Cidades.ToList().ForEach(cidade =>
                {
                    itemCidade.Add(new SelectListItem()
                    {
                        Group = itemUf,
                        Text = cidade.Nome,
                        Value = $"{uf.num_uf}{cidade.num_cidade}"
                    });
                });
            });



            if (Selecionar)
            {
                if (DbUfs.Count() > 0)
                    itemCidade.Insert(0, new SelectListItem() { Text = "Selecione Uma Opção", Value = "", Selected = true });
                else
                    itemCidade.Insert(0, new SelectListItem() { Text = "Não Existem Registro", Value = "", Selected = true });
            }

            ViewBag.Cidades = itemCidade;
        }
 

       
 
       public IActionResult Create()
        {
            GetCombo();
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaID,MatrizID,CodigoCnes,cnpj,Nome,Fantasia,Telefone1,Telefone2,num_cidade ,ImgemFrontEmpresa,Email,Logradouro,numero,bairro,cep,maps,Responsavel,Id_classe,Cert_Empresa,Ativo,TipoEmpresa,url_loja")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                Cidade SelecionadaCidade = null;
                _context
                    .Ufs.Include(x => x.Cidades)
                    .Where(c => c.num_uf.Equals(empresa.num_cidade.Substring(0, 2)))
                    .ToList().ForEach(uf =>
                    {
                        SelecionadaCidade = uf.Cidades.Where(c => c.num_cidade == empresa.num_cidade.Substring(2)).FirstOrDefault();
                    });

                empresa.Cidade = SelecionadaCidade;


                if (string.IsNullOrEmpty(empresa.ImgemFrontEmpresa))
                    empresa.ImgemFrontEmpresa = string.Empty;


                if (string.IsNullOrEmpty(empresa.maps))
                    empresa.maps = string.Empty;


                if (string.IsNullOrEmpty(empresa.url_loja))
                    empresa.url_loja = string.Empty;

                if (string.IsNullOrEmpty(empresa.Email))
                    empresa.Email = string.Empty;


                empresa.Ativo =  Status.Ativo;

               

                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            GetCombo(false);
            return View(empresa);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await (from emp in _context.Empresas.Include(c => c.Cidade).ThenInclude(c => c.Uf)
                                 where emp.EmpresaID == id
                                 select emp).FirstOrDefaultAsync();

            if (empresa == null)
            {
                return NotFound();
            }

            ViewBag.Tipo = (empresa.MatrizID.HasValue);
            GetCombo(false);

            if (empresa.Cidade != null)
            {
                empresa.num_cidade = $"{empresa.Cidade.Uf.num_uf}{empresa.Cidade.num_cidade}";
            }



            if (empresa.MatrizID.HasValue)
                GetMatriz(empresa.MatrizID.Value);
            else
                GetMatriz(0);

            return View(empresa);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpresaID,MatrizID,CodigoCnes,cnpj,Nome,Fantasia,Telefone1,Telefone2,ImgemFrontEmpresa,Email,Logradouro,numero,num_cidade,bairro,cep,maps,Responsavel,Id_classe,Cert_Empresa,Ativo,TipoEmpresa,url_loja")] Empresa empresa)
        {
            if (id != empresa.EmpresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Cidade SelecionadaCidade = null;
                    _context
                        .Ufs.Include(x => x.Cidades)
                        .Where(c => c.num_uf.Equals(empresa.num_cidade.Substring(0, 2)))
                        .ToList().ForEach(uf =>
                     {
                         SelecionadaCidade = uf.Cidades.Where(c => c.num_cidade == empresa.num_cidade.Substring(2)).FirstOrDefault();
                     });



             
                    empresa.Cidade = SelecionadaCidade;


                    if (string.IsNullOrEmpty(empresa.ImgemFrontEmpresa))
                        empresa.ImgemFrontEmpresa = string.Empty;


                    if (string.IsNullOrEmpty(empresa.maps))
                        empresa.maps = string.Empty;


                    if (string.IsNullOrEmpty(empresa.url_loja))
                        empresa.url_loja = string.Empty;

                    if (string.IsNullOrEmpty(empresa.Email))
                        empresa.Email = string.Empty;




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
            GetCombo(false);
            return View(empresa);
        }
 
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
