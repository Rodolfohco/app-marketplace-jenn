using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.portal.jenn.Contract;
using api.portal.jenn.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace api.portal.jenn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMemoryCache cahce;
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteBusiness repositorio;
        private readonly IEmpresaBusiness EmpresaBusiness;

        private readonly IEmailSender _emailSender;
        
        public ClienteController(IEmailSender emailSender,
            IHostingEnvironment env,
            ILogger<ClienteController> logger,
            IClienteBusiness _repositorio,
            IEmpresaBusiness _EmpresaBusiness,
            IMemoryCache _cahce)
        {
            this.EmpresaBusiness = _EmpresaBusiness;
            this._emailSender = emailSender;
            this.repositorio = _repositorio;
            this._logger = logger;
            this.cahce = _cahce;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Post([FromBody] ClienteViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InserirCliente(model);

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

        [HttpPost("InserirContato")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult InserirContato([FromBody] NovoContatoViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InseriContato(new NovoContatoViewModel()
                    {
                        Email = model.Email,
                        mensagem_cont = model.mensagem_cont,
                        Nome = model.Nome,
                        Telefone = model.Telefone

                    });

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


        [HttpPost("InserirContatoProcedimento")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult InserirContatoProcedimento([FromBody] NovoContatoProcedimentoViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InseriContato(new NovoContatoViewModel()
                    {
                        Email = model.Email,
                        mensagem_cont = model.mensagem_cont+ $"Procedimento {model.ProcedimentoID}",
                        Nome = model.Nome,
                        Telefone = model.Telefone

                    });

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

                var item = this.repositorio.SelecionarCliente();

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
        public ICommandResult Delete([FromHeader] int ClienteID)
        {
            CommandResult resultado = null;
            try
            {
                this.repositorio.DeletarCliente(c=> c.ClienteID == ClienteID);
                resultado = new CommandResult(true, "Registro Excluido Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }


        [HttpGet("SelecionarContato")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult SelecionarContato()
        {
            CommandResult resultado = null;
            try
            {

                var item = this.repositorio.SelecionarContato();

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

        [HttpDelete("DeletarContato")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult DeletarContato([FromHeader] int ContatoID)
        {
            CommandResult resultado = null;
            try
            {
                this.repositorio.DeletarContato(c => c.ContatoID == ContatoID);
                resultado = new CommandResult(true, "Registro Excluido Com Sucesso", null, System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }



    }
}
