using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public class ContatoService : IContatoService
    {
        private readonly string Controle;
        private readonly ServiceBase service;
        private readonly IMemoryCache _cache;
        public ContatoService(ServiceBase _service, IMemoryCache memoryCache)
        {
            this.Controle = "Contato";
            this.service = _service;
            _cache = memoryCache;
        }

        public CommandInput Converter(HttpMethod Method, string Controle = null, ContatoViewModel model = null)
        {
            var parametro = new CommandInput();

            if (model != null)
            {
                parametro.Data = new ContatoViewModel();
                parametro.Data = model;
            }

            parametro.Metodo = Method;

            if (!string.IsNullOrEmpty(Controle))
                parametro.UrlAction = Controle;
            else
                parametro.UrlAction = this.Controle;

            return parametro;
        }

        public async Task<CommandResult> Novo(ContatoViewModel model)
        {
            try
            {
                var retorno = await this.service.PostAsync(this.Converter(HttpMethod.Post, "Cliente/InserirContato", model));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
