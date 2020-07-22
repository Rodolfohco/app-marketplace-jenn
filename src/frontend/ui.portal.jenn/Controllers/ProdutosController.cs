using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly ICommandResult resultado;
        public ProdutosController(ILogger<ProdutosController> logger, IProdutoService _produtoService)
        {
            this._logger = logger;
            this.produtoService = _produtoService;
        }

        public IActionResult localidade(string local, string produto)
        {
            return View();
        }

        public IActionResult Lista(PesquisaViewModel model)
        {
            if (model.Produto == null)
                ViewBag.Produto = "Todos os produtos";
            else
                ViewBag.Produto = model.Produto;

            if (model.Localidade == null)
                ViewBag.Localidade = "Todos as localidades";
            else
                ViewBag.Localidade = model.Localidade;


            List<ProcedimentoEmpresa> lista = new List<ProcedimentoEmpresa>();
            lista = produtoService.BuscarProdutosDetalhes(model.Produto, model.Localidade);

            return View(lista);
        }


        public IActionResult Busca(string Produto)
        {
            var lista = new List<PesquisaViewModel>();
            lista.Add(new PesquisaViewModel() { Produto = Guid.NewGuid().ToString(), Localidade = Produto });
            return RedirectToAction("Lista", lista);
        }

        public List<string> BuscarProdutos(string produtos)
        {
            return produtoService.BuscarProdutos(produtos);
        }

        public List<string> BuscarLocalidades(string localidades, string produtos)
        {
            return produtoService.BuscarLocalidades(localidades, produtos);
        }
    }
}
