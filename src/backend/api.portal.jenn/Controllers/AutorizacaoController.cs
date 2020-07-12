using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using security = api.portal.jenn.Utilidade.Cryptography;

namespace api.portal.jenn.Controllers
{
    [AllowAnonymous]
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizacaoController : ControllerBase
    {
        private readonly ILogger<AutorizacaoController> _logger;
        private readonly ILogonBusiness logon;
        private readonly SignInManager<Logon> signInManager;
        private readonly UserManager<Logon> userManager;

        public AutorizacaoController(ILogger<AutorizacaoController> logger,
            ILogonBusiness _logon, SignInManager<Logon> _signInManager, UserManager<Logon> _userManager)
        {
            this.signInManager = _signInManager;
            this.userManager = _userManager;
            this.logon = _logon;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> login (UsuarioViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
            return Ok(result);
        }



        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Logon user = new Logon { UserName = model.Nome, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok(model);
                }
            }
            return Ok(model);

        }
        //[HttpPost]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(500)]
        //public ICommandResult Logon(string email, string senha)
        //{
        //    CommandResult resultado = null;
        //    try
        //    {
        //        var logon = this.logon.Detalhar(c=> c.Email == email && c.Password == security.ComputeSha256Hash(senha));
        //        if (logon != null)
        //        {
        //            var tokenInf = token.GenerateToken(logon);
        //            logon.Password = string.Empty;

        //            var tokenRetorno = new
        //            {
        //                user = logon,
        //                token = tokenInf
        //            };
        //            resultado = new CommandResult(true, "Processado Com Sucesso", tokenRetorno,System.Net.HttpStatusCode.OK);
        //        }
        //        else
        //            resultado = new CommandResult(true, "Usuário ou senha inválidos", null,System.Net.HttpStatusCode.NoContent);
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.LogError($"Ocorreu o Seguinte erro na Api de Autenticação :[{exception.Message}]", exception);
        //    }
        //    return resultado;

        //}
    }
}
