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
    public class ProcedimentoEmpresaController : ControllerBase
    {
        private readonly IMemoryCache cahce;
        private readonly ILogger<ProcedimentoEmpresaController> _logger;
        private readonly IEmpresaBusiness repositorio;


        public ProcedimentoEmpresaController(
          ILogger<ProcedimentoEmpresaController> logger,
          IEmpresaBusiness _repositorio,
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
        public ICommandResult Post([FromBody] NovoProcedimentoEmpresaViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InserirProcedimento(model);

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

        [HttpGet("ProcedimentoEmpresa/{EmpresaID}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult ProcedimentoEmpresa(int EmpresaID)
        {
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.SelecionarProcedimentoEmpresa(EmpresaID);

                if (item != null)
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

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Get()
        {
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.SelecionarProcedimentoEmpresa();

                if (item != null)
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


        [HttpPost("PlanoProcedimentoEmpresas")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult PlanoProcedimentoEmpresas([FromBody] PlanoProcedimentoEmpresaViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InserirPlanoProcedimentoEmpresa(model);

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

        [HttpPost("PagamentoProcedimentoEmpresa")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult PagamentoProcedimentoEmpresa([FromBody] NovoPagamentoProcedimentoEmpresaViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InserirPagamentoProcedimentoEmpresa(model);

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

        [HttpPost("NovoProcedimentoSinonimo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult NovoProcedimentoSinonimo([FromBody] NovoProcedimentoSinonimoViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InsertProcedimentoSinonimo(model);

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



        [HttpGet("GetProcedimentoSinonimoPorId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult GetProcedimentoSinonimoPorId(int ProcedimentoID)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.GetProcedimentoSinonimoID(ProcedimentoID);

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

        [HttpGet("GetProcedimentoSinonimo")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult GetProcedimentoSinonimo()
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.GetProcedimentoSinonimo();

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


        [HttpGet("GetProcedimentoSinonimoPorNome")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult GetProcedimentoSinonimoPorNome(string Nome)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.repositorio.GetProcedimentoSinonimoPorNome(Nome);

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
    }

}