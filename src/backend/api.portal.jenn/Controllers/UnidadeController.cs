using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.portal.jenn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly ILogger<UnidadeController> _logger;
        private readonly IUnidadeBusiness repositorio;
        
        public UnidadeController(ILogger<UnidadeController> logger, IUnidadeBusiness _repositorio)
        {
            this.repositorio = _repositorio;
            this._logger = logger;
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Post([FromBody] UnidadeViewModel model, [FromHeader] Guid EmpresaID)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.Inserir(model, EmpresaID);

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
        public ICommandResult Get([FromHeader] Guid EmpresaID)
        {
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.Selecionar(EmpresaID);

                if (item != null && item.Any())
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


        [HttpGet("Detalha")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Get([FromHeader] Guid EmpresaID, [FromHeader] Guid UnidadeID)
        {
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.Detalhar(c => c.UnidadeID == UnidadeID, EmpresaID);

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
        public ICommandResult Put([FromBody] UnidadeViewModel model, [FromHeader] Guid EmpresaID, [FromHeader] Guid UnidadeID)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    this.repositorio.Atualizar(model, UnidadeID, EmpresaID);
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
        public ICommandResult Delete( [FromHeader] Guid EmpresaID, [FromHeader] Guid UnidadeID)
        {
            CommandResult resultado = null;
            try
            {
                this.repositorio.Excluir(c => c.UnidadeID == UnidadeID, EmpresaID);
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

