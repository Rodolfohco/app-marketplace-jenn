using api.portal.jenn.DTO;
using api.portal.jenn.ViewModel;
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
        ViewModel.ConsultaLogonViewModel Inserir(ViewModel.NovoLogonViewModel model);
   
        void Atualizar(ViewModel.NovoLogonViewModel model, int id);
        ViewModel.ConsultaLogonViewModel Detalhar(Expression<Func<DTO.Logon, bool>> where);
        #endregion
    }
}
