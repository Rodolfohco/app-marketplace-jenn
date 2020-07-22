using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface ILogonRepository
    {
        void Iniciar();
        DTO.Logon Insert(DTO.Logon model);
        IEnumerable<DTO.Logon> Get();
        IEnumerable<DTO.Logon> Get(Expression<Func<DTO.Logon, bool>> where);
        DTO.Logon Detail(Expression<Func<DTO.Logon, bool>> where);
        void Delete(Expression<Func<DTO.Logon, bool>> where);
        void Update(DTO.Logon model, int id);
    }
}
