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
        ViewModel.PlanoViewModel Inserir(ViewModel.PlanoViewModel model, int ConvenioID);
        IEnumerable<ViewModel.PlanoViewModel> Selecionar();
        IEnumerable<ViewModel.PlanoViewModel> Selecionar(int ConvenioID);
        void Excluir(int ConvenioPlanoID, int ConvenioID);
        void Atualizar(ViewModel.PlanoViewModel model, int ConvenioPlanoID, int ConvenioID);
        ViewModel.PlanoViewModel Detalhar(int ConvenioPlanoID, int ConvenioID);
        #endregion

    }

}
