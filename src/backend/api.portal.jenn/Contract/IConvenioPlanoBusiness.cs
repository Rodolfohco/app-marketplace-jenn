using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface IPlanoBusiness
    {

        #region Metodos
        ViewModel.PlanoViewModel Inserir(ViewModel.PlanoViewModel model, Guid ConvenioID);
        IEnumerable<ViewModel.PlanoViewModel> Selecionar();
        IEnumerable<ViewModel.PlanoViewModel> Selecionar(Guid ConvenioID);
        void Excluir(Guid ConvenioPlanoID, Guid ConvenioID);
        void Atualizar(ViewModel.PlanoViewModel model, Guid ConvenioPlanoID, Guid ConvenioID);
        ViewModel.PlanoViewModel Detalhar(Guid ConvenioPlanoID, Guid ConvenioID);
        #endregion

    }

}
