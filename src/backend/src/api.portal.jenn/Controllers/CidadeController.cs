using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.portal.jenn.Business;
using api.portal.jenn.Contract;
using api.portal.jenn.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace api.portal.jenn.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
             private readonly IMemoryCache cahce;
            private readonly ILogger<ConvenioController> _logger;
            private readonly ICidadeBusiness repositorio;
     
            public CidadeController(
                ILogger<ConvenioController> logger,

                ICidadeBusiness _repositorio,
                IMemoryCache _cahce)
            {
                this.repositorio = _repositorio;
                this._logger = logger;
                this.cahce = _cahce;
              
            }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Post([FromBody] NovaCidadeViewModel    model, int EmpresaID)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InserirCidadeEmpresa(model, EmpresaID);

                    if (item != null)
                        resultado = new CommandResult(true, "Processado Com Sucesso", item, System.Net.HttpStatusCode.OK);
                    else
                        resultado = new CommandResult(true, "Processado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
                }
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }

        [HttpPost("InserirCidade")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult InserirCidade([FromBody] NovaCidadeViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InserirCidade(model);

                    if (item != null)
                        resultado = new CommandResult(true, "Processado Com Sucesso", item, System.Net.HttpStatusCode.OK);
                    else
                        resultado = new CommandResult(true, "Processado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
                }
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Get()
        {
            CommandResult resultado = null;
            try
            {

                var item = this.repositorio.SelecionarCidadeEmpresa();

                if (item != null && item.Any())
                    resultado = new CommandResult(true, "Processado Com Sucesso", item, System.Net.HttpStatusCode.OK);
                else
                    resultado = new CommandResult(true, "Processado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);



            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Delete([FromHeader] int CidadeID)
        {
            CommandResult resultado = null;
            try
            {
                this.repositorio.Excluir(c => c.CidadeID == CidadeID);
                resultado = new CommandResult(true, "Registro Excluido Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }

        
        [HttpPut("VincularCidadeEmpresa")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult VincularCidadeEmpresa( int CidadeID, int EmpresaID)
        {
            CommandResult resultado = null;
            try
            {
                if(this.repositorio.VincularEmpresaCidade(CidadeID,EmpresaID))
                    resultado = new CommandResult(true, "Registro Vinculado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
            else
                    resultado = new CommandResult(false, "Falha ao vincular a cidade a Empresa, ação cancelada", null, System.Net.HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }


    }
}
