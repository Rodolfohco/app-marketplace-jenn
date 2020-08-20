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
    public class AgendaController : ControllerBase
    {
        private readonly ILogger<AgendaController> _logger;
        private readonly IEmpresaBusiness repositorio;
        public AgendaController(IEmpresaBusiness _repositorio, ILogger<AgendaController> logger)
        {
            this.repositorio = _repositorio;
            _logger = logger;
        }



        [HttpPost("ConfirmarAgenda")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult ConfirmarAgenda([FromBody] NovaConfirmacaoAgendaViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InserirConfirmacaoAgenda(model);

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
 



        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Post([FromBody] NovoAgendaViewModel model, int ProcedimentoID)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InserirAgendaProcedimentoEmpresa(model, ProcedimentoID);

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
        public async Task<CommandResult> Get(int ProcedimentoID)
        {
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.SelecionarAgendaProcedimentoEmpresa(ProcedimentoID);
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
    }
}
