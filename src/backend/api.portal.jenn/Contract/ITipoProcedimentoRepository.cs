using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface ITipoProcedimentoRepository
    {
        DTO.TipoProcedimento Insert(DTO.TipoProcedimento model);
        IEnumerable<DTO.TipoProcedimento> Get(bool lazzLoader = false);
        IEnumerable<DTO.TipoProcedimento> Get(Expression<Func<DTO.TipoProcedimento, bool>> where, bool lazzLoader = false);
        DTO.TipoProcedimento Detail(Expression<Func<DTO.TipoProcedimento, bool>> where, bool lazzLoader = false);
        void Delete(Expression<Func<DTO.TipoProcedimento, bool>> where);
        void Update(DTO.TipoProcedimento model, int id);
    }
}
