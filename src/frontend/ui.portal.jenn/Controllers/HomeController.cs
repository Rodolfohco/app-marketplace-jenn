using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IMemoryCache cache;
        private readonly ICommandResult resultado;
        public HomeController(ILogger<HomeController> logger, IProdutoService _produtoService, ControleCache _cache)
        {
            this._logger = logger;
            this.produtoService = _produtoService;
            this.cache = _cache.Cache;

            
            //if(!this.cache.TryGetValue("PesquisaCache-Produto", out this.resultado))
            //{
            //    this.resultado = produtoService.Selecionar().Result;
            //    this.cache.Set("PesquisaCache-Produto", this.resultado);
            //}


        }

        public JsonResult AutoCompleteProduto(string nome)
        {
            return new JsonResult("[{Carro }, {Vasoura},{Amar}]");
        }

        public JsonResult AutoCompleteLocalidade(string nome, string localidade)
        {
            return new JsonResult("[{Carro }, {Vasoura},{Amar}]");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pesquisa(PesquisaViewModel model)
        {
            return RedirectToAction("Lista", "Produtos", model);
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
    }
}
