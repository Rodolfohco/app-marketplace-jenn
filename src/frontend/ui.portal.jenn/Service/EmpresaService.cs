using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public class EmpresaService : IEmpresaService
    {
        private readonly string Controle;
        private readonly  ServiceBase service;
        public EmpresaService( ServiceBase _service)
        {
            this.Controle = "Empresa";
            this.service = _service;
        }

        public Task Atualizar(EmpresaViewModel model, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public CommandInput Converter( HttpMethod Method, EmpresaViewModel model = null)
        {
            var parametro = new CommandInput();
            
            if (model != null)
            {
                parametro.Data = new EmpresaViewModel();
                parametro.Data = model;
            }
            
            parametro.Metodo = Method;
            parametro.UrlAction = this.Controle;

            return parametro;
        }
        public CommandInput Converter(HttpMethod Method, string Action, EmpresaViewModel model = null)
        {
            var parametro = new CommandInput();

            if (model != null)
            {
                parametro.Data = new EmpresaViewModel();
                parametro.Data = model;
            }

            parametro.Metodo = Method;
            parametro.UrlAction = $"{this.Controle}/{Action}?EmpresaID={model.EmpresaID}&nome={model.Nome}";

            return parametro;
        }



        public Task DeletarAsync(Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public async Task<CommandResult> Detalhar(Guid EmpresaID)
        {
            try
            {
                var retorno = await this.service.GetAsync(this.Converter(HttpMethod.Get,"Detail", 
                    new EmpresaViewModel() { EmpresaID = EmpresaID } ));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CommandResult> Novo(EmpresaViewModel model)
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
    }

 
}
