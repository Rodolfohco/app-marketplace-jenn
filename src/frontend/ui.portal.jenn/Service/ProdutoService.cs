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

            List<Empresa> listas = dTOEmpresa.data.ToList();
            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<Procedimento> procedimentos = procedimentoEmpresas.Select(p => p.procedimento).Where(p=>p.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produtos))).ToList();

            foreach (var item in procedimentos)
            {
                if (listaFinal.Find(n => n == item.nome) == null)
                    listaFinal.Add(item.nome);
            }
                

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
                        if (empresa.cidade != null)
                        {   
                            if (empresa.cidade.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidades)))
                            {
                                if (listasCidades.Find(n=> n.nome.Contains(empresa.cidade.nome)) == null)
                                    listasCidades.Add(empresa.cidade);
                            }

                        }
                        
                    }
                }));
            }
            else
            {
                listasCidades = listas.Select(c => c.cidade).Where(p => p != null && p.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidades))).ToList();
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
                        if (empresa.cidade != null)
                        {
                            if (localidade == null || empresa.cidade.nome.Contains(localidade))
                            {
                                if (listasEmpresas.Find(n => n.empresaID == empresa.empresaID) == null)
                                    listasEmpresas.Add(empresa);
                            }
                        }
                    }
                }));
            }
            else if(localidade != null)
            {
                localidade = localidade.ToLower();
                listasEmpresas = lista.Where(c => c.cidade != null && c.cidade.nome.ToLower().Contains(localidade)).ToList();
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
                using (var response = client.GetAsync("http://api.examesemcasa.com.br/api/Empresa").Result)
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

        public List<string> BuscarProcedimentos()
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            List<Empresa> listas = dTOEmpresa.data.ToList();
            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<Procedimento> procedimentos = procedimentoEmpresas.Select(p => p.procedimento).ToList();

            foreach (var item in procedimentos)
            {
                if (listaFinal.Find(n => n == item.nome) == null)
                    listaFinal.Add(item.nome);
            }


            return listaFinal;
        }

        public List<string> BuscarPagamentos()
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            List<Empresa> listas = dTOEmpresa.data.ToList();
            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<PagamentoProcedimentoEmpresa> pagamentoProcedimentoEmpresas = procedimentoEmpresas.SelectMany(p => p.pagamentoProcedimentoEmpresas).ToList();

            foreach (var item in pagamentoProcedimentoEmpresas)
            {
                if(item.pagamento != null)
                    if (listaFinal.Find(n => n == item.pagamento.nome) == null)
                        listaFinal.Add(item.pagamento.nome);
            }

            return listaFinal;
        }

        public List<Empresa> BuscarServicosPorDetalhes(List<string> servicos)
        {
            List<Empresa> lista = new List<Empresa>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            dTOEmpresa.data.ToList().ForEach(new Action<Empresa>(delegate (Empresa empresa)
            {
                if (empresa.procedimentoEmpresas != null && empresa.procedimentoEmpresas.Count() > 0)
                {
                    for (int i = 0; i < servicos.Count; i++)
                    {
                        if (empresa.procedimentoEmpresas.Select(x => x.procedimento).Where(c => c.nome.ToLower().Contains(servicos[i])).Count() > 0)
                        {                           
                            if (lista.Find(n => n.empresaID == empresa.empresaID) == null)
                                lista.Add(empresa);                               
                        }
                    }
                }      
            }));

            return lista;
        }

 
        public List<Empresa> BuscarPagamentosPorDetalhes(List<string> pagamentos)
        {
            List<Empresa> lista = new List<Empresa>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            dTOEmpresa.data.ToList().ForEach(new Action<Empresa>(delegate (Empresa empresa)
            {
                if (empresa.procedimentoEmpresas != null && empresa.procedimentoEmpresas.Count() > 0)
                {
                    for (int i = 0; i < pagamentos.Count; i++)
                    {
                        if (empresa.procedimentoEmpresas.SelectMany(x => x.pagamentoProcedimentoEmpresas).Select(x => x.pagamento).Where(c => c.nome.ToLower().Contains(pagamentos[i])).Count() > 0)
                        {
                            if (lista.Find(n => n.empresaID == empresa.empresaID) == null)
                                lista.Add(empresa);
                        }
                    }
                }
            }));

            return lista;
        }


        public List<string> BuscarConvenios()
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            List<Empresa> listas = dTOEmpresa.data.ToList();
            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<PlanoProcedimentoEmpresa> planoProcedimentoEmpresas = procedimentoEmpresas.SelectMany(p => p.planoProcedimentoEmpresas).ToList();

            foreach (var item in planoProcedimentoEmpresas)
            {
                if (item.plano != null)
                    if (item.plano.convenio != null)
                        if (listaFinal.Find(n => n == item.plano.convenio.nome) == null)
                            listaFinal.Add(item.plano.convenio.nome);
            }

            return listaFinal;
        }


        public List<Empresa> BuscarConvenioPorDetalhes(List<string> convenios)
        {
            List<Empresa> lista = new List<Empresa>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            dTOEmpresa.data.ToList().ForEach(new Action<Empresa>(delegate (Empresa empresa)
            {
                if (empresa.procedimentoEmpresas != null && empresa.procedimentoEmpresas.Count() > 0)
                {
                    if (empresa.procedimentoEmpresas.SelectMany(x => x.planoProcedimentoEmpresas).Count() > 0)
                    {
                        for (int i = 0; i < convenios.Count; i++)
                        {
                            if (empresa.procedimentoEmpresas.SelectMany(x => x.planoProcedimentoEmpresas).Select(x => x.plano.convenio).Where(c => c.nome.ToLower().Contains(convenios[i])).Count() > 0)
                            {
                                if (lista.Find(n => n.empresaID == empresa.empresaID) == null)
                                    lista.Add(empresa);
                            }
                        }
                    }
                }
            }));

            return lista;
        }
    }
}
