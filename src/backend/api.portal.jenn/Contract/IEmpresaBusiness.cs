using api.portal.jenn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface IEmpresaBusiness
    {
        #region Metodos
        ViewModel.EmpresaViewModel Inserir(ViewModel.EmpresaViewModel model);
        IEnumerable<ViewModel.EmpresaViewModel> Selecionar();
        IEnumerable<ViewModel.FilialViewModel> SelecionarFiliais();
        IEnumerable<ViewModel.EmpresaViewModel> Selecionar(Expression<Func<DTO.Empresa, bool>> where);
        void Excluir(Expression<Func<DTO.Empresa, bool>> where);
        void Atualizar(ViewModel.EmpresaViewModel model, int id);
        ViewModel.EmpresaViewModel Detalhar(Expression<Func<DTO.Empresa, bool>> where);


        
        IEnumerable<ProcedimentoEmpresaViewModel> SelecionarProcedimentoEmpresa();
        IEnumerable<ProcedimentoEmpresaViewModel> SelecionarProcedimentoEmpresa(int EmpresaID);

        ProcedimentoEmpresaViewModel InserirProcedimento(ProcedimentoEmpresaViewModel model, int EmpresaID, int ProcedimentoID);

        IEnumerable<EmpresaViewModel> Selecionar(bool lazzyLoader = false);
        IEnumerable<ViewModel.EmpresaViewModel> Selecionar(Expression<Func<DTO.Empresa, bool>> where, bool lazzyLoader = false);
        ViewModel.EmpresaViewModel Detalhar(Expression<Func<DTO.Empresa, bool>> where, bool lazzyLoader = false);
        #endregion
    }
}
