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
        private readonly IPlanoBusiness planoRepositorio;
        public ConvenioController(
            ILogger<ConvenioController> logger,
            IPlanoBusiness _planoRepositorio,
            IConvenioBusiness _repositorio,
            IMemoryCache _cahce)
        {
            this.repositorio = _repositorio;
            this._logger = logger;
            this.cahce = _cahce;
            this.planoRepositorio = _planoRepositorio;
        }



        [HttpGet("GetPlanosPorConvenio")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult GetPlanosPorConvenio([FromHeader] int ConvenioID)
        {
            CommandResult resultado = null;
            try
            {
                var item = this.planoRepositorio.Selecionar(ConvenioID);

                if (item != null && item.Any())
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



        [HttpGet("GetPlanos")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult GetPlanos()
        {
            CommandResult resultado = null;
            try
            {
                var item = this.planoRepositorio.Selecionar();

                if (item != null && item.Any())
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

        [HttpPost("NovoPlano") ]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult NovoPlano([FromHeader] int ConvenioID, [FromBody] PlanoViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.planoRepositorio.Inserir(model, ConvenioID);

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



        [HttpGet("DetalharPlano/{ConvenioID}/{ConvenioPlanoID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult DetalharPlano(int ConvenioID, int ConvenioPlanoID)
        {
            CommandResult resultado = null;
            try
            {
                var item = this.planoRepositorio.Detalhar(ConvenioPlanoID, ConvenioID);
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

        [HttpPut("AtualizarPlano")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult AtualizarPlano([FromBody] PlanoViewModel model, [FromHeader] int ConvenioPlanoID, [FromHeader] int ConvenioID)
        {
            CommandResult resultado = null;
            try
            {

                if (ModelState.IsValid)
                {

                    this.planoRepositorio.Atualizar(model, ConvenioPlanoID, ConvenioID);
                    resultado = new CommandResult(true, "Registro Atualizado Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
                }

            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }

        [HttpDelete("DeletarPlano")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult DeletarPlano([FromHeader] int ConvenioID, [FromHeader] int ConvenioPlanoID)
        {
            CommandResult resultado = null;
            try
            {

                this.planoRepositorio.Excluir(ConvenioPlanoID, ConvenioID);
                resultado = new CommandResult(true, "Registro Excluido Com Sucesso", null, System.Net.HttpStatusCode.NoContent);

            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.Message}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
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


                    cahce.Set("data-Convenio", resultado);
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
        public ICommandResult Detalhe(int ConvenioID)
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
        public ICommandResult Put([FromBody] ConvenioViewModel model, [FromHeader] int ConvenioID)
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
        public ICommandResult Delete([FromHeader] int ConvenioID)
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
