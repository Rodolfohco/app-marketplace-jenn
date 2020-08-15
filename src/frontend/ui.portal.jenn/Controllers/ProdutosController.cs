using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
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
                ViewBag.Localidade = "Todas as localidades";
            else
                ViewBag.Localidade = model.Localidade;

            ViewBag.IdProcedimento = model.IdProcedimento;
            PesquisaViewModel model2 = new PesquisaViewModel();
            model2.Produto = ViewBag.Produto;
            model2.Localidade = ViewBag.Localidade;

            HttpContext.Session.SetString("filtroPesquisa", JsonConvert.SerializeObject(model2));

            List<Empresa> lista = new List<Empresa>();
            lista = produtoService.BuscarProdutosDetalhes(model.IdProcedimento, model.Localidade);

            return View(lista);
        }

        public IActionResult ListaTipoProduto(string TipoProduto)
        {
           
            ViewBag.Produto = TipoProduto;
            ViewBag.Localidade = "Todos as localidades";

            PesquisaViewModel model = new PesquisaViewModel();
            model.Produto = TipoProduto;
            model.Localidade = "Todos as localidades";

            HttpContext.Session.SetString("filtroPesquisa", JsonConvert.SerializeObject(model));



            List<Empresa> lista = new List<Empresa>();
            lista = produtoService.BuscarTipoProdutosDetalhes(TipoProduto);

            return View("Lista",lista);
        }

        public IActionResult ListarPorBairros(List<string> bairro)
        {

            ViewBag.Produto = "Todos os produtos";
            ViewBag.Localidade = "Bairros";


            List<Empresa> lista = new List<Empresa>();
            lista = produtoService.BuscarBairroPorDetalhes(bairro);

            return View("Lista", lista);
        }
        


        public IActionResult Busca(string Produto)
        {
            var lista = new List<PesquisaViewModel>();
            lista.Add(new PesquisaViewModel() { Produto = Guid.NewGuid().ToString(), Localidade = Produto });
            return RedirectToAction("Lista", lista);
        }

        public List<DTOAutocomplete> BuscarProdutos(string produtos)
        {
            return produtoService.BuscarProdutos(produtos);
        }

        public List<DTOAutocomplete> BuscarLocalidades(string localidades, string produtos)
        {
            return produtoService.BuscarLocalidades(localidades, produtos);
        }

        public IActionResult ListarPorServicos(List<string> procedimento)
        {

            ViewBag.Produto = "Produtos";
            ViewBag.Localidade = "Todas a localidades";


            List<Empresa> lista = new List<Empresa>();
            lista = produtoService.BuscarServicosPorDetalhes(procedimento);

            return View("Lista", lista);
        }

        public IActionResult ListarPorPagamentos(List<string> pagamento)
        {

            ViewBag.Produto = "Pagamentos";
            ViewBag.Localidade = "Todas a localidades";


            List<Empresa> lista = new List<Empresa>();
            lista = produtoService.BuscarPagamentosPorDetalhes(pagamento);

            return View("Lista", lista);
        }

        public IActionResult ListarPorConvenio(List<string> conveniopesquisas)
        {

            ViewBag.Produto = "Convenios";
            ViewBag.Localidade = "Todas a localidades";


            List<Empresa> lista = new List<Empresa>();
            lista = produtoService.BuscarConvenioPorDetalhes(conveniopesquisas);

            return View("Lista", lista);
        }

        [HttpGet]
        public IActionResult ListarPorFiltros(List<string> bairro = null, List<string> procedimento = null, List<string> pagamento = null, List<string> conveniopesquisas = null)
        {

            List<Empresa> lista = new List<Empresa>();
            string produtos = "";
            string localidades = "";

            if (conveniopesquisas.Count() > 0)
            {
                lista = produtoService.BuscarConvenioPorDetalhes(conveniopesquisas);
                produtos += " Convenios ";
            }

            if (pagamento.Count() > 0)
            {
                lista = produtoService.BuscarPagamentosPorDetalhes(pagamento, lista);
                produtos += " Pagamentos ";
            }

            if (procedimento.Count() > 0)
            {
                lista = produtoService.BuscarServicosPorDetalhes(procedimento, lista);
                produtos += " Serviços ";
            }


            if (bairro.Count() > 0)
            {
                lista = produtoService.BuscarBairroPorDetalhes(bairro, lista);
                localidades = "Bairros";
            }

            ViewBag.Produto = produtos == "" ? ViewBag.Produto = "Filtros" : ViewBag.Produto = produtos; ;
            ViewBag.Localidade = localidades == "" ? ViewBag.Localidade = "Todas as Localidades" : ViewBag.Localidade = localidades;

            return View("Lista", lista);
        }

         

        public IActionResult Agendamento(int id, int idProcedimento)
        {
            AgendamentoViewModel agendamentoViewModel = new AgendamentoViewModel();

            agendamentoViewModel.PesquisaViewModel = produtoService.BuscarEmpresaPorId(id, idProcedimento);
            agendamentoViewModel.Convenios = produtoService.BuscarConvenios();
            ViewBag.idProcedimento = idProcedimento;

            return View("Agendamento", agendamentoViewModel);
        }

        public IActionResult FinalizarAgendamento(AgendamentoViewModel model)
        {
            string mensagem = "Agendamento enviado com sucesso, em breve entraremos em contato.";
            return View("FinalizarAgendamento", mensagem);
        }

    }
}
