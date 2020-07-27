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
            produtos = produtos.ToLower();
            List<Cidade> listasCidades = new List<Cidade>();
            /*
            List<Empresa> listas = dTOEmpresa.data.ToList();
            listas = listas.Select(pe => pe.procedimentoEmpresas).Select(p => p.procedimento).Where(p => p.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produtos))).ToList();
            List<Procedimento> procedimentos = procedimentoEmpresas.Select(p => p.procedimento).Where(p => p.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produtos))).ToList();



            if (produtos != null)
                listas = dTOEmpresa.data.Where(p=>p.procedimento.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produtos))).Select(e=> e.empresa).SelectMany(e => e.cidades).Where(p => p.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidades))).ToList();
            else
                listas = dTOEmpresa.data.Select(e => e.empresa).SelectMany(e => e.cidades).Where(p => p.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidades))).ToList();

            foreach (var item in listas)
                listaFinal.Add(item.nome);
           */
            return listaFinal;
        }

        public List<ProcedimentoEmpresa> BuscarProdutosDetalhes(string produto,  string localidade)
        {
            List<ProcedimentoEmpresa> lista = new List<ProcedimentoEmpresa>();

            DTOEmpresa dTOEmpresa = BuscarEmpresas();
                 /*
            lista = dTOEmpresa.data.ToList();
            if (produto != null)
                lista = dTOEmpresa.data.Where(p => p.procedimento.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produto))).ToList();

            if (localidade != null)
                lista = dTOEmpresa.data.Where(p => p.empresa.cidades.Count() > 0 &&   p.empresa.cidades.FirstOrDefault().nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidade))).ToList();
                 */
            return lista;
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


        public List<ProcedimentoEmpresa> BuscarTipoProdutosDetalhes(string tipoproduto)
        {
            List<ProcedimentoEmpresa> lista = new List<ProcedimentoEmpresa>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();                 
            /*
            lista = dTOEmpresa.data.ToList();
            if (tipoproduto != null)
                lista = dTOEmpresa.data.Where(p => p.procedimento.tipoProcedimento.nome==tipoproduto).ToList();
            */
            return lista;
        }


        public List<TipoProcedimentoViewModel> BuscarTipoProdutos()
        {
            List<TipoProcedimentoViewModel> listaFinal = new List<TipoProcedimentoViewModel>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();
            /*
            List<Tipoprocedimento> listas = dTOEmpresa.data.Select(p => p.procedimento).Select(a=>a.tipoProcedimento).Take(10).ToList();

            foreach (var item in listas)
            {
                TipoProcedimentoViewModel tipoProcedimento = new  TipoProcedimentoViewModel();
                tipoProcedimento.Nome = item.nome;
                if(listaFinal.Where(t => t.TipoProcedimentoID == tipoProcedimento.TipoProcedimentoID).Count() == 0)
                    listaFinal.Add(tipoProcedimento);
            }
               */
            return listaFinal;
        }

        public List<string> BuscarBairros()
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();
            /*
            List<Empresa> listas = dTOEmpresa.data.Select(p => p.empresa).ToList();

            foreach (var item in listas)
                listaFinal.Add(item.bairro);
            */
            return listaFinal;

        }

        public List<ProcedimentoEmpresa> BuscarBairroPorDetalhes(List<string> bairros)
        {
            List<ProcedimentoEmpresa> lista = new List<ProcedimentoEmpresa>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();
            /*
            for (int i = 0; i < bairros.Count; i++)
            {
                lista.AddRange(dTOEmpresa.data.Where(p => p.empresa.bairro.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(bairros[i]))).ToList());
            }
               */

            return lista;
        }
    }
}
