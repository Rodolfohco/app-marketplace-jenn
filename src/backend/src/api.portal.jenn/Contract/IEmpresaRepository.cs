using api.portal.jenn.DTO;
using api.portal.jenn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{

    public interface IEmpresaRepository
    {
        IEnumerable<ProcedimentoEmpresa> GetProcedimentoEmpresa(int EmpresaID);
        IEnumerable<ProcedimentoEmpresa> GetProcedimentoEmpresa();
        DTO.ProcedimentoEmpresa Insert(DTO.ProcedimentoEmpresa model);

        DTO.ConfirmacaoAgenda InsertConfirmacaoAgenda(ConfirmacaoAgendaViewModel model);



        DTO.PagamentoProcedimentoEmpresa Insert(DTO.PagamentoProcedimentoEmpresa model, int ProcedimentoID);

        DTO.PlanoProcedimentoEmpresa InsertPlanoProcedimentoEmpresa(PlanoProcedimentoEmpresa model, int ProcedimentoID);

        DTO.FotoEmpresa Insert(DTO.FotoEmpresa model, int EmpresaID);
        DTO.Grupo Insert(DTO.Grupo model, int EmpresaID);


        IEnumerable<DTO.Agenda> GetNovaAgenda(int ProcedimentoID, bool lazzLoader = false);
        DTO.Agenda InsertNovaAgenda(DTO.Agenda model, int ProcedimentoID);
        IEnumerable<DTO.Empresa> GetFiliais(bool lazzLoader = false);


        DTO.Empresa Insert(DTO.Empresa model);
        IEnumerable<DTO.Empresa> Get(bool lazzLoader = false);
        IEnumerable<DTO.Empresa> Get(Expression<Func<DTO.Empresa, bool>> where, bool lazzLoader = false);
        DTO.Empresa Detail(Expression<Func<DTO.Empresa, bool>> where, bool lazzLoader = false);
        void Delete(Expression<Func<DTO.Empresa, bool>> where);
        void Update(DTO.Empresa model, int id);
    }

 
}