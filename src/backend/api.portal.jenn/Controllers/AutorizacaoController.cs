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
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
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
        private readonly ITokenService token;

        public AutorizacaoController(ILogger<AutorizacaoController> logger, ITokenService _token,
            ILogonBusiness _logon, SignInManager<Logon> _signInManager, UserManager<Logon> _userManager)
        {
            this.signInManager = _signInManager;
            this.userManager = _userManager;
            this.logon = _logon;
            _logger = logger;
            this.token = _token;
        }


        [HttpPost]
        public async Task<IActionResult> login (UsuarioViewModel model)
        {


            return Ok(token.GenerateToken(new LogonViewModel() { Nome = model.Nome, Email = model.Email }));

        
        
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
                else
                    return BadRequest(result);
            }
            else
                return BadRequest();

        }

    }
}
