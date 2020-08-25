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

        public IActionResult ListarPorBairros(int idProcedimento, List<string> bairro)
        {

            ViewBag.Produto = "Todos os produtos";
            ViewBag.Localidade = "Cidades";
            ViewBag.idProcedimento = idProcedimento;

            List<Empresa> lista = new List<Empresa>();
            lista = produtoService.BuscarBairroPorDetalhes(bairro, null, idProcedimento);

            if (lista.Count > 0)
                if (lista.FirstOrDefault().procedimentoEmpresas.Count() > 0)
                    if (lista.FirstOrDefault().procedimentoEmpresas.FirstOrDefault().procedimento != null)
                        ViewBag.Produto = lista.FirstOrDefault().procedimentoEmpresas.FirstOrDefault().procedimento.nome;

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
            lista = produtoService.BuscarServicosPorDetalhes(procedimento, null);

            return View("Lista", lista);
        }

        public IActionResult ListarPorPagamentos(int idProcedimento, List<string> pagamento)
        {

            ViewBag.Produto = "Pagamentos";
            ViewBag.Localidade = "Todas a localidades";
            ViewBag.idProcedimento = idProcedimento;


            List<Empresa> lista = new List<Empresa>();
            lista = produtoService.BuscarPagamentosPorDetalhes(pagamento, null, idProcedimento);

            if (lista.Count > 0)
                if (lista.FirstOrDefault().procedimentoEmpresas.Count() > 0)
                    if (lista.FirstOrDefault().procedimentoEmpresas.FirstOrDefault().procedimento != null)
                        ViewBag.Produto = lista.FirstOrDefault().procedimentoEmpresas.FirstOrDefault().procedimento.nome;

            return View("Lista", lista);
        }

        public IActionResult ListarPorConvenio(int idProcedimento, List<string> conveniopesquisas)
        {

            ViewBag.Produto = "Convenios";
            ViewBag.Localidade = "Todas a localidades";
            ViewBag.idProcedimento = idProcedimento;


            List<Empresa> lista = new List<Empresa>();
            lista = produtoService.BuscarConvenioPorDetalhes(conveniopesquisas,null, idProcedimento);

            if (lista.Count > 0)
                if (lista.FirstOrDefault().procedimentoEmpresas.Count() > 0)
                    if (lista.FirstOrDefault().procedimentoEmpresas.FirstOrDefault().procedimento != null)
                        ViewBag.Produto = lista.FirstOrDefault().procedimentoEmpresas.FirstOrDefault().procedimento.nome;

            return View("Lista", lista);
        }

        [HttpGet]
        public IActionResult ListarPorFiltros(int idProcedimento, List<string> bairro = null, List<string> procedimento = null, List<string> pagamento = null, List<string> conveniopesquisas = null)
        {

            List<Empresa> lista = new List<Empresa>();
            string produtos = "";
            string localidades = "";

            if (conveniopesquisas.Count() > 0)
            {
                lista = produtoService.BuscarConvenioPorDetalhes(conveniopesquisas, null, idProcedimento);
                produtos += " Convenios ";
            }

            if (pagamento.Count() > 0)
            {
                lista = produtoService.BuscarPagamentosPorDetalhes(pagamento, lista, idProcedimento);
                produtos += " Pagamentos ";
            }

            if (bairro.Count() > 0)
            {
                lista = produtoService.BuscarBairroPorDetalhes(bairro, lista, idProcedimento);
                localidades = "Cidades";
            }

            ViewBag.Produto = produtos == "" ? ViewBag.Produto = "Filtros" : ViewBag.Produto = produtos;

            if (procedimento.Count() > 0)
            {
                lista = produtoService.BuscarServicosPorDetalhes(procedimento, lista);
                produtos += " Serviços ";
            }
            else
            {
                if (lista.Count > 0)
                    if (lista.FirstOrDefault().procedimentoEmpresas.Count() > 0)
                        if (lista.FirstOrDefault().procedimentoEmpresas.FirstOrDefault().procedimento != null)
                            ViewBag.Produto = lista.FirstOrDefault().procedimentoEmpresas.FirstOrDefault().procedimento.nome;

            }
                        
            ViewBag.Localidade = localidades == "" ? ViewBag.Localidade = "Todas as Localidades" : ViewBag.Localidade = localidades;
            ViewBag.idProcedimento = idProcedimento;


            return View("Lista", lista);
        }

         

        public IActionResult Agendamento(int id, int idProcedimento, int idAgenda)
        {
            AgendamentoViewModel agendamentoViewModel = new AgendamentoViewModel();

            agendamentoViewModel.PesquisaViewModel = produtoService.BuscarEmpresaPorId(id, idProcedimento);
            agendamentoViewModel.Convenios = produtoService.BuscarConvenios();
            ViewBag.idProcedimento = idProcedimento;
            agendamentoViewModel.AgendaID = idAgenda;
            agendamentoViewModel.PesquisaViewModel.IdProcedimentoEmpresa = idProcedimento;

            return View("Agendamento", agendamentoViewModel);
        }

        public async Task<IActionResult> FinalizarAgendamento(AgendamentoViewModel model)
        {
            string mensagem = "";

            CommandResult agendamento = new CommandResult(true, "", "", null, System.Net.HttpStatusCode.BadRequest);
            try
            {
                    agendamento = await produtoService.SalvarAgendamentoPaciente(model);

                    if (agendamento != null && agendamento.Success)
                    {
                        mensagem = "Olá Agradecemos pelo agendamento, um dos nossos consultores entrara em contato em breve!";
                    }
                    else
                        mensagem = "Por favor tente um pouco mais tarde, Pedimos desculpas pelo ocorrido";
            
            }
            catch (Exception)
            {
                this._logger.LogError("Ocorreu o Seguinte Erro", agendamento.Message);
            }

            return View("FinalizarAgendamento", mensagem);
        }

        public IActionResult TipoProcedimentoLista(int TipoProcedimentoID, string TipoProduto)
        {
            ViewBag.TipoProcedimento = TipoProduto;
            Dictionary<int, string> lista = new Dictionary<int, string>();
            lista = produtoService.BuscarProcedimentosPorTipo(TipoProcedimentoID);

            return View("TipoProcedimentoLista", lista);
        }

    }
}
