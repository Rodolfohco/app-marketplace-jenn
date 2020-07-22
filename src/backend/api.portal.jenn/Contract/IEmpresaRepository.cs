using api.portal.jenn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{

    public interface IEmpresaRepository
    {
        IEnumerable<ProcedimentoEmpresa> GetProcedimentoEmpresa(Guid EmpresaID);
        IEnumerable<ProcedimentoEmpresa> GetProcedimentoEmpresa();
        DTO.ProcedimentoEmpresa Insert(DTO.ProcedimentoEmpresa model, Guid EmpresaID, Guid ProcedimentoID);






        DTO.Empresa Insert(DTO.Empresa model);
        IEnumerable<DTO.Empresa> Get(bool lazzLoader = false);
        IEnumerable<DTO.Empresa> Get(Expression<Func<DTO.Empresa, bool>> where, bool lazzLoader = false);
        DTO.Empresa Detail(Expression<Func<DTO.Empresa, bool>> where, bool lazzLoader = false);
        void Delete(Expression<Func<DTO.Empresa, bool>> where);
        void Update(DTO.Empresa model, Guid id);
    }

 
}