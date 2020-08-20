using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface IProcedimentoBusiness
    {
        #region Metodos
        ViewModel.ProcedimentoViewModel Inserir(ViewModel.NovoProcedimentoViewModel model);
        ViewModel.ProcedimentoViewModel Inserir(ViewModel.ProcedimentoViewModel model);
        IEnumerable<ViewModel.ProcedimentoViewModel> Selecionar();


        IEnumerable<ViewModel.CidadeViewModel> SelecionarCidades(string nomeProcedimento);
        IEnumerable<ViewModel.ProcedimentoViewModel> Selecionar(Expression<Func<DTO.Procedimento, bool>> where);
        void Excluir(Expression<Func<DTO.Procedimento, bool>> where);
        void Atualizar(ViewModel.ProcedimentoViewModel model, int id);
        ViewModel.ProcedimentoViewModel Detalhar(Expression<Func<DTO.Procedimento, bool>> where);

        #endregion
    }
}
