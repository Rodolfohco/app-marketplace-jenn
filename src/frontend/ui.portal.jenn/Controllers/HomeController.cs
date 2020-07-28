using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ui.portal.jenn.Handler;
using ui.portal.jenn.Models;
using ui.portal.jenn.Service;
using ui.portal.jenn.ViewModel;



namespace ui.portal.jenn.Controllers
{



    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutoService produtoService;
        private readonly ILogonService logonService;
        private readonly IMemoryCache cache;
        private readonly ICommandResult resultado;
        public HomeController(ILogger<HomeController> logger, IProdutoService _produtoService, ILogonService _logonService, ControleCache _cache)
        {
            this._logger = logger;
            this.produtoService = _produtoService;
            this.cache = _cache.Cache;
            this.logonService = _logonService;

      


        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pesquisa(PesquisaViewModel model)
        {
            return RedirectToAction("Lista", "Produtos", model);
        }

        public IActionResult CentralAjuda()
        {
            return View();
        }

        public IActionResult MeuPainel()
        {
            return View();
        }

        public IActionResult Index(PesquisaViewModel model)
        {
            return View(model);
        }

        public IActionResult Inicio()
        {
            PesquisaViewModel pesquisaViewModel = new PesquisaViewModel();
            pesquisaViewModel.tipoProcedimentoViewModels = produtoService.BuscarTipoProdutos();

            return View(pesquisaViewModel);
        }
 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }








        #region Metodos Logon / Central Ajuda
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(NovoLogonViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Papeis = new List<RolesViewModel>();
                model.Papeis.Add(new RolesViewModel() { Role = "Cliente" });

                var autenticacao = await logonService.Novo(model);
            }
            return View(model);
        }

        public IActionResult Autenticar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Autenticar(AutenticarLogonViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var autenticacao =   logonService.LocalizarUsuario(model);
                    var retorno = autenticacao.Result;

                    AutenticacaoViewModel autenticado = new AutenticacaoViewModel(retorno);

                    if (retorno.Status == System.Net.HttpStatusCode.OK)
                    {
                        var authProperties = new AuthenticationProperties
                        {
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                            IssuedUtc = DateTime.Now,
                            IsPersistent = true
                        };
                        var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, autenticado.Usuario.Nome),
                        new Claim(ClaimTypes.Email,autenticado.Usuario.Email),
                        new Claim(ClaimTypes.CookiePath, retorno.Token),
                    };
                        var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);


                          HttpContext.SignInAsync(
                         CookieAuthenticationDefaults.AuthenticationScheme,
                         new ClaimsPrincipal(claimsIdentity),
                         authProperties).Wait();


                        return RedirectToActionPermanent("MeuPainel", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Usuário ou Senha inválida...";
                        return View(model);
                    }
                }
                else
                    return View(model);
            }
            finally
            {

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Inicio", "Home");            
        }
       public async Task<IActionResult> AccessDenied()
        {
            return View();

        }


        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contato(ContatoViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }


        #endregion
    }
}
