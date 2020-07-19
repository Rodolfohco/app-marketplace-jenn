using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ui.portal.jenn.Handler;
using ui.portal.jenn.Service;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ILogger<ProdutosController> _logger;
        private readonly IProdutoService produtoService;
        private readonly IMemoryCache cache;
        private readonly ICommandResult resultado;
        public ProdutosController(ILogger<ProdutosController> logger, IProdutoService _produtoService, ControleCache _cache)
        {
            this._logger = logger;
            this.produtoService = _produtoService;
            this.cache = _cache.Cache;
        }

        public IActionResult localidade(string local, string produto)
        {
            return View();
        }

        public IActionResult Lista(PesquisaViewModel model)
        {
            var lista = new List<PesquisaViewModel>();

            lista.Add(new PesquisaViewModel() { Produto = Guid.NewGuid().ToString(), Localidade = "Teste" });
            lista.Add(new PesquisaViewModel() { Produto = Guid.NewGuid().ToString(), Localidade = "Teste" });
            lista.Add(new PesquisaViewModel() { Produto = Guid.NewGuid().ToString(), Localidade = "Teste" });
            lista.Add(new PesquisaViewModel() { Produto = Guid.NewGuid().ToString(), Localidade = "Teste" });
            lista.Add(new PesquisaViewModel() { Produto = Guid.NewGuid().ToString(), Localidade = "Teste" });
            lista.Add(new PesquisaViewModel() { Produto = Guid.NewGuid().ToString(), Localidade = "Teste" });
            return View(lista);
        }

        public IActionResult Busca(string Produto)
        {
            var lista = new List<PesquisaViewModel>();
            lista.Add(new PesquisaViewModel() { Produto = Guid.NewGuid().ToString(), Localidade = Produto });
            return RedirectToAction("Lista", lista);
        }

    }
}
