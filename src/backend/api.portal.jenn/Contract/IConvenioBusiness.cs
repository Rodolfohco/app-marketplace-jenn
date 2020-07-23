using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface IConvenioBusiness
    {

        #region Metodos
        ViewModel.ConvenioViewModel Inserir(ViewModel.ConvenioViewModel model);
        IEnumerable<ViewModel.ConvenioViewModel> Selecionar();
        IEnumerable<ViewModel.ConvenioViewModel> Selecionar(Expression<Func<DTO.Convenio, bool>> where);
        void Excluir(Expression<Func<DTO.Convenio, bool>> where);
        void Atualizar(ViewModel.ConvenioViewModel model, int id);
        ViewModel.ConvenioViewModel Detalhar(Expression<Func<DTO.Convenio, bool>> where);
        #endregion

    }    
}

