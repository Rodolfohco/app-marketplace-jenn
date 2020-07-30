using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly IContatoService contatoService;
        private readonly IMemoryCache cache;
        public HomeController(
            ILogger<HomeController> logger,
            IProdutoService _produtoService,
            ILogonService _logonService, IContatoService _contatoService, ControleCache _cache)
        {
            this._logger = logger;
            this.produtoService = _produtoService;
            this.cache = _cache.Cache;
            this.logonService = _logonService;
            this.contatoService = _contatoService;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pesquisa(PesquisaViewModel model)
        {
 
                HttpContext.Session.SetString("filtroPesquisa", JsonConvert.SerializeObject(model));
            return RedirectToAction("Lista", "Produtos", model);
        }

        public IActionResult CentralAjuda()
        {
            return View();
        }

        [Authorize]
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
                return RedirectToAction("Inicio", "Home");
            }
            return View(model);
        }

        public IActionResult Autenticar()
        {
            return View();
        }
 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Autenticar(AutenticarLogonViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var autenticacao = await logonService.LocalizarUsuario(model);
                    var retorno = autenticacao;

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
        public IActionResult AccessDenied()
        {
            return View();
        }


        public IActionResult QuemSomos()
        {
            return View();
        }


        public IActionResult TermosCondicoes()
        {
            return View();
        }


        public IActionResult SegurancaInformacao()
        {
            return View();
        }


        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contato(ContatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contato = await contatoService.Novo(model);

                if (contato != null && contato.Success)
                    return RedirectToAction("Inicio");
                else
                    ModelState.AddModelError("Erro", contato.Message);
            }
            return View(model);
        }


        #endregion
    }
}
