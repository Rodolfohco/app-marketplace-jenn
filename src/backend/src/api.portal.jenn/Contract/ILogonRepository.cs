using api.portal.jenn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface ILogonRepository
    {
        Task<DTO.Logon> DetailAsync(Expression<Func<DTO.Logon, bool>> where);
        DTO.Logon Insert(DTO.Logon model, Cliente cliente);
        DTO.Logon Insert(DTO.Logon model);
        DTO.Logon Detail(Expression<Func<DTO.Logon, bool>> where);
        void Update(DTO.Logon model, int id);
    }
}
