using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly string Controle;
        private readonly ServiceBase service;
        public ProdutoService(ServiceBase _service)
        {
            this.Controle = "Produto";
            this.service = _service;
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

    
 
    }
}
