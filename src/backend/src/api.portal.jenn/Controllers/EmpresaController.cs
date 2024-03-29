﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using api.portal.jenn.Contract;
using api.portal.jenn.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;



namespace api.portal.jenn.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        private readonly ILogger<EmpresaController> _logger;
        private readonly IEmpresaBusiness repositorio;
  

        public EmpresaController(ILogger<EmpresaController> logger, IEmpresaBusiness _repositorio, IProcedimentoBusiness _procedimentoRepositorio)
        {
            this.repositorio = _repositorio;
            this._logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Post([FromBody] NovaEmpresaViewModel model)
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
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]",System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }


        

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<CommandResult> Get()
        {   
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.Selecionar();



                item.ToList().ForEach(it =>
                {
                    it.ProcedimentoEmpresas = it.ProcedimentoEmpresas.Where(x => x.Ativo > 0).ToList();
                });


             

                if (item != null && item.Any())
                    resultado = new CommandResult(true, "Processado Com Sucesso", item, System.Net.HttpStatusCode.OK);
                else
                    resultado = new CommandResult(true, "Processado Com Sucesso", null,System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]",System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }


        [HttpGet("Detalha")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Get([FromHeader] int EmpresaID)
        {
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.Detalhar(C=> C.EmpresaID==EmpresaID);           

                if (item != null)
                    resultado = new CommandResult(true, "Processado Com Sucesso", item,System.Net.HttpStatusCode.OK);
                else
                    resultado = new CommandResult(true, "Processado Com Sucesso", null,System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]",System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Put([FromBody] EmpresaViewModel model, [FromHeader]  int EmpresaID)
        {
            CommandResult resultado = null;
            try
            {

                if (ModelState.IsValid)
                {
                    this.repositorio.Atualizar(model, EmpresaID);
                    resultado = new CommandResult(true, "Registro Atualizado Com Sucesso", null,System.Net.HttpStatusCode.NoContent);
                }
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]",System.Net.HttpStatusCode.BadRequest);
            }
            return resultado;
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult Delete([FromHeader] int EmpresaID )
        {
            CommandResult resultado = null;
            try
            {
                this.repositorio.Excluir(c => c.EmpresaID == EmpresaID);
                resultado = new CommandResult(true, "Registro Excluido Com Sucesso", null,System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]",System.Net.HttpStatusCode.BadRequest);
            }
            return resultado;
        }


        [HttpPost("NovaFilial")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult NovaFilial([FromBody] NovaFilialViewModel model)
        {
            CommandResult resultado = null;
            try
            {


                if (ModelState.IsValid)
                {
                    var item = this.repositorio.InserirFilial(model);

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

        [HttpGet("GetFiliais")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<CommandResult> GetFiliais()
        {
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.SelecionarFilial();
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


        [HttpGet("DetalhaFilial")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult DetalhaFilial(  int EmpresaID, int FilialID)
        {
            CommandResult resultado = null;
            try
            {
                var item = this.repositorio.DetalharFilial(EmpresaID, FilialID);

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



        [HttpPost("NovaFotoEmpresa")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult NovaFotoEmpresa([FromBody] FotoEmpresaViewModel model, int EmpresaID)
        {
            CommandResult resultado = null;
            try
            {


                if (ModelState.IsValid)
                {
                    var item = this.repositorio.Inserir(model, EmpresaID);

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


        [HttpPost("GrupoEmpresa")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult GrupoEmpresa([FromBody] GrupoViewModel model, int EmpresaID)
        {
            CommandResult resultado = null;
            try
            {


                if (ModelState.IsValid)
                {
                    var item = this.repositorio.Inserir(model, EmpresaID);

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
