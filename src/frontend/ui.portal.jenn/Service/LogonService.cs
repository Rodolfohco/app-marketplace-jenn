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
    public class LogonService : ILogonService
    {
        private readonly string Controle;
        private readonly ServiceBase service;
        private readonly IMemoryCache _cache;
        public LogonService(ServiceBase _service, IMemoryCache memoryCache)
        {
            this.Controle = "Logon";
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

        public CommandInput Converter(HttpMethod Method, string Controle = null, AutenticarLogonViewModel model = null)
        {
            var parametro = new CommandInput();

            if (model != null)
            {
                parametro.Data = new AutenticarLogonViewModel();
                parametro.Data = model;
            }

            parametro.Metodo = Method;

            if (!string.IsNullOrEmpty(Controle))
                parametro.UrlAction = Controle;
            else
                parametro.UrlAction = this.Controle;

            return parametro;
        }

        public CommandInput Converter(HttpMethod Method, string Controle=null, NovoLogonViewModel model = null)
        {
            var parametro = new CommandInput();

            if (model != null)
            {
                parametro.Data = new NovoLogonViewModel();
                parametro.Data = model;
            }

            
            parametro.Metodo = Method;

            if (!string.IsNullOrEmpty(Controle))
                parametro.UrlAction = Controle;
                else
                parametro.UrlAction = this.Controle;

            return parametro;
        }

       
 
     
        public async Task<CommandResult> LocalizarUsuario(AutenticarLogonViewModel model)
        {
            try
            {
                var retorno = await this.service.PostAsync(this.Converter(HttpMethod.Post,"", model));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<CommandResult> Novo(NovoLogonViewModel model) 
        { 
         try
            {
                var retorno = await this.service.PostAsync(this.Converter(HttpMethod.Post, "Logon/CriarLogon", model));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
