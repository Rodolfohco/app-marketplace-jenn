using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.Utilidade;
using api.portal.jenn.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using security = api.portal.jenn.Utilidade.Cryptography;

namespace api.portal.jenn.Controllers
{

    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class LogonController : ControllerBase
    {
        private readonly ILogger<LogonController> _logger;
        private readonly ILogonBusiness logon;
        private readonly ITokenService token;
        public LogonController(ILogger<LogonController> logger, ILogonBusiness _logon, ITokenService _token)
        {
            this.logon = _logon;
            _logger = logger;
            this.token = _token;

        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ICommandResult> Post([FromBody] AutenticarLogonViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = await this.logon.DetalharAsync(model.Email, model.Password);

                    if (item != null)
                        resultado = new CommandResult(true, "Usuário Autenticado com Sucesso", this.token.GenerateToken(item), item, System.Net.HttpStatusCode.OK);
                    else
                        resultado = new CommandResult(true, "Usuário ou senha Invalido", null, System.Net.HttpStatusCode.NoContent);
                }
            }
            catch (Exception e)
            {
                resultado = new CommandResult(false, "Falha no processamento, segue detalhes do erro", $"Descrição do erro :[{e.InnerException}]", System.Net.HttpStatusCode.BadRequest);
            }

            return resultado;
        }


        [HttpPost("CriarLogon")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ICommandResult CriarLogon([FromBody] NovoLogonViewModel model)
        {
            CommandResult resultado = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var item = this.logon.Inserir(model);

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