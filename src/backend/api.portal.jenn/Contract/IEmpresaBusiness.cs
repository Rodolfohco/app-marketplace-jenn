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
        IEnumerable<ViewModel.EmpresaViewModel> Selecionar(Expression<Func<DTO.Empresa, bool>> where);
        void Excluir(Expression<Func<DTO.Empresa, bool>> where);
        void Atualizar(ViewModel.EmpresaViewModel model, Guid id);
        ViewModel.EmpresaViewModel Detalhar(Expression<Func<DTO.Empresa, bool>> where);


        IEnumerable<ProcedimentoEmpresaViewModel> SelecionarProcedimentoEmpresa();
        IEnumerable<ProcedimentoEmpresaViewModel> SelecionarProcedimentoEmpresa(Guid EmpresaID);

        ProcedimentoEmpresaViewModel InserirProcedimento(ProcedimentoEmpresaViewModel model, Guid EmpresaID, Guid ProcedimentoID);

        IEnumerable<EmpresaViewModel> Selecionar(bool lazzyLoader = false);
        IEnumerable<ViewModel.EmpresaViewModel> Selecionar(Expression<Func<DTO.Empresa, bool>> where, bool lazzyLoader = false);
        ViewModel.EmpresaViewModel Detalhar(Expression<Func<DTO.Empresa, bool>> where, bool lazzyLoader = false);
        #endregion
    }
}
