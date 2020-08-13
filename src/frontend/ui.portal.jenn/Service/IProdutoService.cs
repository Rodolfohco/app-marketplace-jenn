using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.Models;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public interface IProdutoService
    {
        CommandInput Converter(HttpMethod Method, ProdutoViewModel model = null);
        Task<CommandResult> Selecionar();
        Task DeletarAsync(Guid EmpresaID);

        Task<CommandResult> Novo(ProdutoViewModel model);

        Task Atualizar(ProdutoViewModel model, Guid EmpresaID);
        Task<CommandResult> Detalhar(Guid EmpresaID);
        List<DTOAutocomplete> BuscarProdutos(string produtos);
        List<DTOAutocomplete> BuscarLocalidades(string localidades, string produtos);
        List<Empresa> BuscarProdutosDetalhes(int produto, string localidade);
        List<Empresa> BuscarTipoProdutosDetalhes(string tipoproduto);
        List<TipoProcedimentoViewModel> BuscarTipoProdutos();
        List<string> BuscarBairros();
        List<Empresa> BuscarBairroPorDetalhes(List<string> bairros, List<Empresa> empresas = null);
        List<string> BuscarProcedimentos();
        List<string> BuscarPagamentos();
        List<Empresa> BuscarServicosPorDetalhes(List<string> servicos, List<Empresa> empresas = null);
        List<Empresa> BuscarPagamentosPorDetalhes(List<string> pagamentos, List<Empresa> empresas = null);
        List<string> BuscarConvenios();
        List<Empresa> BuscarConvenioPorDetalhes(List<string> convenios, List<Empresa> empresas = null);
        PesquisaViewModel BuscarEmpresaPorId(int id, int idProcedimento);
        Procedimento BuscarProdutosPorId(int produto);
    }
   
}
