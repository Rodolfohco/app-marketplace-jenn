using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface ICategoriaProcedimentoRepository
    {

        DTO.CategoriaProcedimento Insert(DTO.CategoriaProcedimento model);
        IEnumerable<DTO.CategoriaProcedimento> Get(bool lazzLoader = false);
        IEnumerable<DTO.CategoriaProcedimento> Get(Expression<Func<DTO.CategoriaProcedimento, bool>> where, bool lazzLoader = false);
        DTO.CategoriaProcedimento Detail(Expression<Func<DTO.CategoriaProcedimento, bool>> where, bool lazzLoader = false);
        void Delete(Expression<Func<DTO.CategoriaProcedimento, bool>> where);
        void Update(DTO.CategoriaProcedimento model, int id);
    }
}
