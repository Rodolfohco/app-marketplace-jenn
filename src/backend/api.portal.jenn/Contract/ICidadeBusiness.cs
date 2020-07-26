using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
   public interface ICidadeBusiness
    {
        #region Metodos
        ViewModel.CidadeViewModel InserirCidadeEmpresa(ViewModel.CidadeViewModel model, int EmpresaID);
        ViewModel.CidadeViewModel InserirCidadeCliente(ViewModel.CidadeViewModel model, int ClienteID);



        IEnumerable<ViewModel.CidadeViewModel> SelecionarCidadeCliente();
        IEnumerable<ViewModel.CidadeViewModel> SelecionarCidadeEmpresa();
        IEnumerable<ViewModel.CidadeViewModel> SelecionarCidadeCliente(Expression<Func<DTO.Cidade, bool>> where, int ClienteID);
        IEnumerable<ViewModel.CidadeViewModel> SelecionarCidadeEmpresa(Expression<Func<DTO.Cidade, bool>> where, int EmpresaID);

        void Excluir(Expression<Func<DTO.Cidade, bool>> where);


        void AtualizarCidadeCliente(ViewModel.CidadeViewModel model, int ClienteID);
        void AtualizarCidadeEmpresa(ViewModel.CidadeViewModel model, int EmpresaId );


        ViewModel.CidadeViewModel Detalhar(Expression<Func<DTO.Cidade, bool>> where);
        #endregion
    }
}
