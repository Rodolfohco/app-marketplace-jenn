using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
   

    public interface IProcedimentoRepository
    {
        DTO.Procedimento Insert(DTO.Procedimento model);
        IEnumerable<DTO.Procedimento> Get(bool lazzLoader = false);
        IEnumerable<DTO.Procedimento> Get(Expression<Func<DTO.Procedimento, bool>> where, bool lazzLoader = false);
        DTO.Procedimento Detail(Expression<Func<DTO.Procedimento, bool>> where, bool lazzLoader = false);
        void Delete(Expression<Func<DTO.Procedimento, bool>> where);
        void Update(DTO.Procedimento model, Guid id);

    }


}
