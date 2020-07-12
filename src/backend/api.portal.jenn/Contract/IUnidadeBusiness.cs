using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
   public interface IUnidadeBusiness
    {
        #region Metodos
        ViewModel.UnidadeViewModel Inserir(ViewModel.UnidadeViewModel model, Guid EmpresaID);
        IEnumerable<ViewModel.UnidadeViewModel> Selecionar(Guid EmpresaID);
        IEnumerable<ViewModel.UnidadeViewModel> Selecionar(Func<DTO.Unidade, bool> where, Guid EmpresaID);
        void Excluir(Expression<Func<DTO.Unidade, bool>> where, Guid EmpresaID);
        void Atualizar(ViewModel.UnidadeViewModel model, Guid UnidadeId, Guid EmpresaID);
        ViewModel.UnidadeViewModel Detalhar(Func<DTO.Unidade, bool> where, Guid EmpresaID);
        #endregion
    }
}
