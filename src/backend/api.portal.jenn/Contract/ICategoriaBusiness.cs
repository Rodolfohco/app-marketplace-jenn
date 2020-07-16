using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface ICategoriaProcedimentoBusiness
    {

        #region Metodos
        ViewModel.CategoriaViewModel Inserir(ViewModel.CategoriaViewModel model);
        IEnumerable<ViewModel.CategoriaViewModel> Selecionar();
        IEnumerable<ViewModel.CategoriaViewModel> Selecionar(Expression<Func<DTO.CategoriaProcedimento, bool>> where);
        void Excluir(Expression<Func<DTO.CategoriaProcedimento, bool>> where);
        void Atualizar(ViewModel.CategoriaViewModel model, Guid id);
        ViewModel.CategoriaViewModel Detalhar(Expression<Func<DTO.CategoriaProcedimento, bool>> where);
        #endregion
    }
}
