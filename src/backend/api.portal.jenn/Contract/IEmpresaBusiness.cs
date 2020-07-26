using api.portal.jenn.DTO;
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
        EmpresaViewModel Inserir(ViewModel.NovaEmpresaViewModel model);
        FotoEmpresaViewModel Inserir(ViewModel.FotoEmpresaViewModel model, int EmpresaID);
        GrupoViewModel Inserir(ViewModel.GrupoViewModel model, int EmpresaID);
        IEnumerable<ViewModel.ConsultaEmpresaViewModel> Selecionar();
 
        IEnumerable<ViewModel.ConsultaEmpresaViewModel> Selecionar(Expression<Func<DTO.Empresa, bool>> where);
        void Excluir(Expression<Func<DTO.Empresa, bool>> where);
        void Atualizar(ViewModel.EmpresaViewModel model, int id);
        ViewModel.EmpresaViewModel Detalhar(Expression<Func<DTO.Empresa, bool>> where);





        ViewModel.FilialViewModel InserirFilial(ViewModel.NovaFilialViewModel model);
        IEnumerable<ViewModel.FilialViewModel> SelecionarFilial();

        ViewModel.FilialViewModel DetalharFilial(int EmpresaID, int FilialID);
        void ExcluirFilial(Expression<Func<DTO.Empresa, bool>> where);
        void AtualizarFilial(ViewModel.FilialViewModel model, int id);





        IEnumerable<ConsultaProcedimentoEmpresaViewModel> SelecionarProcedimentoEmpresa();
        IEnumerable<ConsultaProcedimentoEmpresaViewModel> SelecionarProcedimentoEmpresa(int EmpresaID);

        ConsultaProcedimentoEmpresaViewModel InserirProcedimento(NovoProcedimentoEmpresaViewModel model);

        IEnumerable<EmpresaViewModel> Selecionar(bool lazzyLoader = false);
        IEnumerable<ViewModel.EmpresaViewModel> Selecionar(Expression<Func<DTO.Empresa, bool>> where, bool lazzyLoader = false);
        ViewModel.EmpresaViewModel Detalhar(Expression<Func<DTO.Empresa, bool>> where, bool lazzyLoader = false);


        ViewModel.PlanoProcedimentoEmpresaViewModel InserirPlanoProcedimentoEmpresa(PlanoProcedimentoEmpresaViewModel model);

        ViewModel.PagamentoProcedimentoEmpresaViewModel InserirPagamentoProcedimentoEmpresa(ViewModel.NovoPagamentoProcedimentoEmpresaViewModel model);


        #endregion
    }
}
