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
    public class ProcedimentoController : ControllerBase
    {
        private readonly IMemoryCache cahce;
        private readonly ILogger<ProcedimentoController> _logger;
        private readonly IProcedimentoBusiness repositorio;
        private readonly ITipoProcedimentoBusiness tipoProcedimento; 

        public ProcedimentoController(
            ILogger<ProcedimentoController> logger,
            IProcedimentoBusiness _repositorio,
             ITipoProcedimentoBusiness _tipoProcedimento,
            IMemoryCache _cahce)
        {
            this.tipoProcedimento = _tipoProcedimento;

            this.repositorio = _repositorio;
            this._logger = logger;
            this.cahce = _cahce;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Post([FromBody] ProcedimentoViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.Inserir(model);

                    if (item != null)
                        resultado = new CommandResult(true, "Processado Com Sucesso", item, System.Net.HttpStatusCode.OK);
                    else
                        resultado = new CommandResult(true, "Processado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
                }
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]", System.Net.HttpStatusCode.BadRequest);
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
                if (cahce.TryGetValue("data-procedimento", out IEnumerable<ViewModel.ProcedimentoViewModel> convenio))
                    resultado = new CommandResult(true, "Processado Com Sucesso", convenio, System.Net.HttpStatusCode.OK);
                else
                {
                    var item = this.repositorio.Selecionar();

                    if (item != null && item.Any())
                        resultado = new CommandResult(true, "Processado Com Sucesso", item, System.Net.HttpStatusCode.OK);
                    else
                        resultado = new CommandResult(true, "Processado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);


                    cahce.Set("data-procedimento", item);

                }
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }


        [HttpGet("CidadesProcedimento/{nomeProcedimento}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult CidadesProcedimento(string nomeProcedimento)
        {
            CommandResult resultado = null;
            try
            {
                if (cahce.TryGetValue("data-procedimento", out IEnumerable<ViewModel.ProcedimentoViewModel> convenio))
                    resultado = new CommandResult(true, "Processado Com Sucesso", convenio, System.Net.HttpStatusCode.OK);
                else
                {
                    var item = this.repositorio.Selecionar();

                    if (item != null && item.Any())
                        resultado = new CommandResult(true, "Processado Com Sucesso", item, System.Net.HttpStatusCode.OK);
                    else
                        resultado = new CommandResult(true, "Processado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);


                    cahce.Set("data-procedimento", item);

                }
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }

        [HttpGet("Detalhe/{ProcedimentoID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Detalhe(int ProcedimentoID)
        {
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.Detalhar(c => c.ProcedimentiID == ProcedimentoID);

                if (item != null)
                    resultado = new CommandResult(true, "Processado Com Sucesso", item, System.Net.HttpStatusCode.OK);
                else
                    resultado = new CommandResult(true, "Processado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Put([FromBody] ProcedimentoViewModel model, [FromHeader] int ProcedimentoID)
        {
            CommandResult resultado = null;
            try
            {

                if (ModelState.IsValid)
                {

                    this.repositorio.Atualizar(model, ProcedimentoID);
                    resultado = new CommandResult(true, "Registro Atualizado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
                }

            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Delete([FromHeader] int ProcedimentoID)
        {
            CommandResult resultado = null;
            try
            {
                this.repositorio.Excluir(c => c.ProcedimentiID == ProcedimentoID);
                resultado = new CommandResult(true, "Registro Excluido Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }


        [HttpGet("TipoProcedimento")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult TipoProcedimento()
        {
            CommandResult resultado = null;
            try
            {
                    var item = this.tipoProcedimento.Selecionar();

                    if (item != null && item.Any())
                        resultado = new CommandResult(true, "Processado Com Sucesso", item, System.Net.HttpStatusCode.OK);
                    else
                        resultado = new CommandResult(true, "Processado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);


                    cahce.Set("data-procedimento", item);

              
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }


    }
}
 