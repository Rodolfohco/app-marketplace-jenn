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
        IEnumerable<ConsultaProcedimentoSinonimoViewModel> GetProcedimentoSinonimoID(int ProcedimentoID);

        IEnumerable<ConsultaProcedimentoSinonimoViewModel> GetProcedimentoSinonimoPorNome(string PorNome);

        IEnumerable<ConsultaProcedimentoSinonimoViewModel> GetProcedimentoSinonimo();



        ConsultaProcedimentoSinonimoViewModel InsertProcedimentoSinonimo(NovoProcedimentoSinonimoViewModel model);

        ConsultaProcedimentoEmpresa2ViewModel DetalharProcedimentoEmpresa(int ProcedimentoEmpresaID);

        #region Metodos
        EmpresaViewModel Inserir(ViewModel.NovaEmpresaViewModel model);
        FotoEmpresaViewModel Inserir(ViewModel.FotoEmpresaViewModel model, int EmpresaID);
        GrupoViewModel Inserir(ViewModel.GrupoViewModel model, int EmpresaID);
        IEnumerable<ViewModel.ConsultaEmpresaViewModel> Selecionar();
 
        IEnumerable<ViewModel.ConsultaEmpresaViewModel> Selecionar(Expression<Func<DTO.Empresa, bool>> where);
        void Excluir(Expression<Func<DTO.Empresa, bool>> where);
        void Atualizar(ViewModel.EmpresaViewModel model, int id);
        ViewModel.EmpresaViewModel Detalhar(Expression<Func<DTO.Empresa, bool>> where);
        EmpresaViewModel DetalharMatriz(string nome);
        EmpresaViewModel Detalhar(string nome);

        ViewModel.FilialViewModel InserirFilial(ViewModel.NovaFilialViewModel model);
        IEnumerable<ViewModel.ConsultaFilialViewModel> SelecionarFilial();

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

        IEnumerable<ConsultaAgendaViewModel> SelecionarAgendaProcedimentoEmpresa(int ProcedimentoID);
        ConsultaAgendaViewModel InserirAgendaProcedimentoEmpresa(NovoAgendaViewModel novaAgenda, int ProcedimentoEmpresaID);

        ConsultaNovaConfirmacaoAgendaViewModel InserirConfirmacaoAgenda(NovaConfirmacaoAgendaViewModel novaAgenda );
        #endregion
    }
}
