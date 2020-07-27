using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
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
        List<string> BuscarProdutos(string produtos);
        List<string> BuscarLocalidades(string localidades, string produtos);
        List<Empresa> BuscarProdutosDetalhes(string produto, string localidade);
        List<Empresa> BuscarTipoProdutosDetalhes(string tipoproduto);
        List<TipoProcedimentoViewModel> BuscarTipoProdutos();
        List<string> BuscarBairros();
        List<Empresa> BuscarBairroPorDetalhes(List<string> bairros);
    }
   
}
