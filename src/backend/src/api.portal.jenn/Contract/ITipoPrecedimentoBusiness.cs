using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{


                     
    public interface ITipoProcedimentoBusiness
    {


        #region Metodos
        ViewModel.TipoProcedimentoViewModel Inserir(ViewModel.TipoProcedimentoViewModel model);
        IEnumerable<ViewModel.TipoProcedimentoViewModel> Selecionar();
        IEnumerable<ViewModel.TipoProcedimentoViewModel> Selecionar(Expression<Func<DTO.TipoProcedimento, bool>> where);
        void Excluir(Expression<Func<DTO.TipoProcedimento, bool>> where);
        void Atualizar(ViewModel.TipoProcedimentoViewModel model, int id);
        ViewModel.TipoProcedimentoViewModel Detalhar(Expression<Func<DTO.TipoProcedimento, bool>> where);
        #endregion
    }
}
