using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface ILogonBusiness
    {

        #region Metodos
        ViewModel.LogonViewModel Inserir(ViewModel.LogonViewModel model);
        IEnumerable<ViewModel.LogonViewModel> Selecionar();
        IEnumerable<ViewModel.LogonViewModel> Selecionar(Expression<Func<DTO.Logon, bool>> where);
        void Excluir(Expression<Func<DTO.Logon, bool>> where);
        void Atualizar(ViewModel.LogonViewModel model, Guid id);
        ViewModel.LogonViewModel Detalhar(Expression<Func<DTO.Logon, bool>> where);
        #endregion
    }
}
