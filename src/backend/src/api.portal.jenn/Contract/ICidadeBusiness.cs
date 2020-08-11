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
        ViewModel.CidadeViewModel InserirCidadeEmpresa(ViewModel.NovaCidadeViewModel model, int EmpresaID);
        ViewModel.CidadeViewModel InserirCidadeCliente(ViewModel.NovaCidadeViewModel model, int ClienteID);



      bool VincularEmpresaCidade(int CidadeID, int EmpresaID);
        bool VincularClienteCidade(int CidadeID, int ClienteID);

        ViewModel.CidadeViewModel InserirCidade(ViewModel.NovaCidadeViewModel model);

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
