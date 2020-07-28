using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public class ProcedimentoEmpresaService : IProcedimentoEmpresaService
    {
        private readonly string Controle;
        private readonly ServiceBase service;
        private readonly IMemoryCache cache;

        public ProcedimentoEmpresaService(ServiceBase _service, IMemoryCache memoryCache)
        {
            this.Controle = "ProcedimentoEmpresa";
            this.service = _service;
            this.cache = memoryCache;
        }

        public CommandInput Converter(HttpMethod Method, string Controle = null, ProcedimentoEmpresaViewModel model = null)
        {
            var parametro = new CommandInput();

            if (model != null)
            {
                parametro.Data = new ProcedimentoEmpresaViewModel();
                parametro.Data = model;
            }

            parametro.Metodo = Method;

            if (!string.IsNullOrEmpty(Controle))
                parametro.UrlAction = Controle;
            else
                parametro.UrlAction = this.Controle;

            return parametro;
        }

        public async Task<ProcedimentoEmpresaViewModel> DetalhaProcedimentoEmpresa(int ProcedimentoID)
        {
            ProcedimentoEmpresaViewModel retorno = null;
            try
            {
                var retornoHttp = await this.service.GetAsync(this.Converter(HttpMethod.Get, $"/Procedimento/Detalhe/{ProcedimentoID}", null));

                if (retornoHttp.Status == HttpStatusCode.OK)
                {
                    if (retornoHttp.Data != null && retornoHttp.Data.ToString().Length > 3)
                    {
                        string json = retornoHttp.Data.ToString();
                        retorno = JsonConvert.DeserializeObject<ProcedimentoEmpresaViewModel>(json);
                    }
                }
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<ProcedimentoEmpresaViewModel>> ListaProcedimentoEmpresa()
        {
            IEnumerable<ProcedimentoEmpresaViewModel> retorno = Enumerable.Empty<ProcedimentoEmpresaViewModel>();
            try
            {
                if (!this.cache.TryGetValue("cache_Procedimento_empresa", out retorno))
                {
                    var retornoHttp = await this.service.GetAsync(this.Converter(HttpMethod.Get, "", null));

                    if (retornoHttp.Status == HttpStatusCode.OK)
                    {
                        if (retornoHttp != null && retornoHttp.Data.ToString().Length > 3)
                        {
                            string json = retornoHttp.Data.ToString();
                            retorno = JsonConvert.DeserializeObject<IEnumerable<ProcedimentoEmpresaViewModel>>(json);
                        }
                    }
                    this.cache.Set("cache_Procedimento_empresa", retorno);
                }

                return retorno;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
