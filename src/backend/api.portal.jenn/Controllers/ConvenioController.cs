using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.portal.jenn.Contract;
using api.portal.jenn.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace api.portal.jenn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvenioController : ControllerBase
    {

        private readonly IMemoryCache cahce;
        private readonly ILogger<ConvenioController> _logger;
        private readonly IConvenioBusiness repositorio;
        private readonly ITokenService token;
        public ConvenioController(ILogger<ConvenioController> logger, IConvenioBusiness _repositorio, IMemoryCache _cahce)
        {
            this.repositorio = _repositorio;
            this._logger = logger;
            this.cahce = _cahce;


        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Post([FromBody] ConvenioViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.Inserir(model);

                    if (item != null)
                        resultado = new CommandResult(true, "Processado Com Sucesso", item,System.Net.HttpStatusCode.OK);
                    else
                        resultado = new CommandResult(true, "Processado Com Sucesso", null,System.Net.HttpStatusCode.NoContent);
                }
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]",System.Net.HttpStatusCode.BadRequest);
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
                if (cahce.TryGetValue("data-Convenio", out IEnumerable<ViewModel.ConvenioViewModel> convenio))
                    resultado = new CommandResult(true, "Processado Com Sucesso", convenio,System.Net.HttpStatusCode.OK);
                else
                {
                    var item = this.repositorio.Selecionar();

                    if (item != null && item.Any())
                        resultado = new CommandResult(true, "Processado Com Sucesso", item,System.Net.HttpStatusCode.OK);
                    else
                        resultado = new CommandResult(true, "Processado Com Sucesso", null,System.Net.HttpStatusCode.NoContent);


                    cahce.Set("data-Convenio", item);

                }
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]",System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }

        [HttpGet("Detalhe/{ConvenioID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Detalhe(Guid ConvenioID)
        {
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.Detalhar(c => c.Id == ConvenioID);

                if (item != null)
                    resultado = new CommandResult(true, "Processado Com Sucesso", item,System.Net.HttpStatusCode.OK);
                else
                    resultado = new CommandResult(true, "Processado Com Sucesso", null,System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]",System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Put([FromBody] ConvenioViewModel model, [FromHeader] Guid ConvenioID)
        {
            CommandResult resultado = null;
            try
            {

                if (ModelState.IsValid)
                {

                    this.repositorio.Atualizar(model, ConvenioID);
                    resultado = new CommandResult(true, "Registro Atualizado Com Sucesso", null,System.Net.HttpStatusCode.NoContent);
                }

            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]",System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Delete([FromHeader] Guid ConvenioID)
        {
            CommandResult resultado = null;
            try
            {
                this.repositorio.Excluir(c => c.Id == ConvenioID);
                resultado = new CommandResult(true, "Registro Excluido Com Sucesso", null,System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]",System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }
    }
}
