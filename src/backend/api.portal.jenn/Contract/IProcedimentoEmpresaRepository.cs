using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface IProcedimentoEmpresaRepository
    {

        DTO.ProcedimentoEmpresa Insert(DTO.ProcedimentoEmpresa model);
        IEnumerable<DTO.ProcedimentoEmpresa> Get(bool lazzLoader = false);
        IEnumerable<DTO.ProcedimentoEmpresa> Get(Expression<Func<DTO.ProcedimentoEmpresa, bool>> where, bool lazzLoader = false);
        DTO.ProcedimentoEmpresa Detail(Expression<Func<DTO.ProcedimentoEmpresa, bool>> where, bool lazzLoader = false);
        void Delete(Expression<Func<DTO.ProcedimentoEmpresa, bool>> where);
        void Update(DTO.ProcedimentoEmpresa model, int id);

    }
}
