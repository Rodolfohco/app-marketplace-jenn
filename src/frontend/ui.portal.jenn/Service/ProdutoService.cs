using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly string Controle;
        private readonly ServiceBase service;
        private readonly IMemoryCache _cache;
        public ProdutoService(ServiceBase _service, IMemoryCache memoryCache)
        {
            this.Controle = "Produto";
            this.service = _service;
            _cache = memoryCache;
        }

        
        public CommandInput Converter(HttpMethod Method, ProdutoViewModel model = null)
        {
            var parametro = new CommandInput();

            if (model != null)
            {
                parametro.Data = new ProdutoViewModel();
                parametro.Data = model;
            }

            parametro.Metodo = Method;
            parametro.UrlAction = this.Controle;

            return parametro;
        }
        public CommandInput Converter(HttpMethod Method, string Action, ProdutoViewModel model = null)
        {
            var parametro = new CommandInput();

            if (model != null)
            {
                parametro.Data = new ProdutoViewModel();
                parametro.Data = model;
            }

            parametro.Metodo = Method;
            parametro.UrlAction = $"{this.Controle}/{Action}?EmpresaID={model.ProdutoID}&nome={model.Produto}";

            return parametro;
        }



        public Task DeletarAsync(Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public async Task<CommandResult> Detalhar(Guid ProdutoID)
        {
            try
            {
                var retorno = await this.service.GetAsync(this.Converter(HttpMethod.Get, "Detail",
                    new ProdutoViewModel() { ProdutoID = ProdutoID }));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CommandResult> Novo(ProdutoViewModel model)
        {
            try
            {
                var retorno = await this.service.PostAsync(this.Converter(HttpMethod.Post, model));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CommandResult> Selecionar()
        {
            try
            {
                var retorno = await this.service.GetAsync(this.Converter(HttpMethod.Get));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Task Atualizar(ProdutoViewModel model, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }


        public List<string> BuscarProdutos(string produtos)
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            produtos = produtos.ToLower();
            //List<Empresa> listas = dTOEmpresa.data.Select(p=>p.procedimentoEmpresas.Select(c=>c.procedimento).Where(p=>p.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produtos)))).ToList();


            List<Empresa> listas = dTOEmpresa.data.ToList();
            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<Procedimento> procedimentos = procedimentoEmpresas.Select(p => p.procedimento).Where(p=>p.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produtos))).ToList();

            foreach (var item in procedimentos)
                listaFinal.Add(item.nome);

            return listaFinal;
        }

        public List<string> BuscarLocalidades(string localidades, string produtos)
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            localidades = localidades.ToLower();
            List<Cidade> listasCidades = new List<Cidade>();
            List<Empresa> listas = dTOEmpresa.data.ToList();

            if(produtos != null)
            {
                produtos = produtos.ToLower();
                listas.ForEach(new Action<Empresa>(delegate (Empresa empresa)
                {
                    if (empresa.procedimentoEmpresas.Select(x => x.procedimento).Where(c => c.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produtos))) != null)
                    {
                        if (empresa.cidade.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidades)))
                        {
                            if (listasCidades.Find(n=> n.nome.Contains(empresa.cidade.nome)) == null)
                                listasCidades.Add(empresa.cidade);
                        }
                    }
                }));
            }
            else
            {
                listasCidades = listas.Select(c => c.cidade).Where(p => p.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidades))).ToList();
            }

            foreach (var item in listasCidades)
                if (listaFinal.IndexOf(item.nome) == -1)
                    listaFinal.Add(item.nome);

            return listaFinal;


        }

        public List<Empresa> BuscarProdutosDetalhes(string produto,  string localidade)
        {
            List<Empresa> lista = new List<Empresa>();
            List<Empresa> listasEmpresas = new List<Empresa>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            lista = dTOEmpresa.data.ToList();

            if (produto != null)
            {
                produto = produto.ToLower();
                lista.ForEach(new Action<Empresa>(delegate (Empresa empresa)
                {
                    if (empresa.procedimentoEmpresas.Select(x => x.procedimento).Where(c => c.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produto))) != null)
                    {
                        if (empresa.cidade.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidade)))
                        {
                            if (listasEmpresas.Find(n => n.empresaID == empresa.empresaID) == null)
                                listasEmpresas.Add(empresa);
                        }
                    }
                }));
            }
            else if(localidade != null)
            {
                listasEmpresas = lista.Where(c => c.cidade.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidade))).ToList();
            }
            else
            {
                listasEmpresas = lista;
            }
           
            

            return listasEmpresas;
        }

        private DTOEmpresa getProcedimentoEmpresa()
        {
            using (var client = new HttpClient())
            {
<<<<<<< HEAD
                using (var response = client.GetAsync("http://api.examesemcasa.com.br/api/ProcedimentoEmpresa").Result)
=======
                using (var response = client.GetAsync("http://api.examesemcasa.com.br/api/Empresa").Result)
>>>>>>> a6244138870ba5ca2aeaab8f54ce3ea73698a84f
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<DTOEmpresa>(JsonString);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        private DTOEmpresa BuscarEmpresas()
        {
            string cacheKey = "DTOEmpresa";
            DTOEmpresa dTOEmpresa = _cache.Get<DTOEmpresa>(cacheKey);

            if (dTOEmpresa == null)
            {
                dTOEmpresa = getProcedimentoEmpresa();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(20));
                _cache.Set<DTOEmpresa>(cacheKey, dTOEmpresa, cacheEntryOptions);
            }

            return dTOEmpresa;
        }


        public List<Empresa> BuscarTipoProdutosDetalhes(string tipoproduto)
        {
            List<Empresa> lista = new List<Empresa>();
            List<Empresa> listasEmpresas = new List<Empresa>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();                 
            
            lista = dTOEmpresa.data.ToList();

            if (tipoproduto != null)
            {
                tipoproduto = tipoproduto.ToLower();
                lista.ForEach(new Action<Empresa>(delegate (Empresa empresa)
                {
                    if (empresa.procedimentoEmpresas.Select(x => x.procedimento).Where(c => c.tipoProcedimento.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tipoproduto))) != null)
                    {                        
                        if (listasEmpresas.Find(n => n.empresaID == empresa.empresaID) == null)
                            listasEmpresas.Add(empresa);                       
                    }
                }));
            }

            return lista;
        }


        public List<TipoProcedimentoViewModel> BuscarTipoProdutos()
        {
            List<TipoProcedimentoViewModel> listaFinal = new List<TipoProcedimentoViewModel>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            //List<Tipoprocedimento> listas = dTOEmpresa.data.Select(p => p.procedimento).Select(a=>a.tipoProcedimento).Take(10).ToList();
            List<Empresa> listas = dTOEmpresa.data.ToList();
            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<Procedimento> procedimentos = procedimentoEmpresas.Select(p => p.procedimento).ToList();


            foreach (var item in procedimentos)
            {
                TipoProcedimentoViewModel tipoProcedimento = new  TipoProcedimentoViewModel();
                tipoProcedimento.Nome = item.tipoProcedimento.nome;
                if(listaFinal.Where(t => t.TipoProcedimentoID == tipoProcedimento.TipoProcedimentoID).Count() == 0)
                    listaFinal.Add(tipoProcedimento);
            }
              
            return listaFinal;
        }

        public List<string> BuscarBairros()
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();
            
            List<Empresa> listas = dTOEmpresa.data.Where(e=>e.matriz != null).ToList();

            foreach (var item in listas)
                listaFinal.Add(item.bairro);
            
            return listaFinal;

        }

        public List<Empresa> BuscarBairroPorDetalhes(List<string> bairros)
        {
            List<Empresa> lista = new List<Empresa>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();
            
            for (int i = 0; i < bairros.Count; i++)
            {
                lista.AddRange(dTOEmpresa.data.Where(p => p.bairro.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(bairros[i]))).ToList());
            }
              

            return lista;
        }
    }
}
