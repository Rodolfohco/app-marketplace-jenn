using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
   public  interface IClienteRepository
    {
        DTO.Contato Insert(DTO.Contato model);
        DTO.Contato Detail(Expression<Func<DTO.Contato, bool>> where, bool lazzLoader = false);
        void Delete(Expression<Func<DTO.Contato, bool>> where);
        IEnumerable<DTO.Contato> GetContato(bool lazzLoader = false);
        IEnumerable<DTO.Contato> Get(Expression<Func<DTO.Contato, bool>> where, bool lazzLoader = false);



        DTO.Cliente Insert(DTO.Cliente model);
        DTO.Cliente Detail(Expression<Func<DTO.Cliente, bool>> where, bool lazzLoader = false);
        void Delete(Expression<Func<DTO.Cliente, bool>> where);

        IEnumerable<DTO.Cliente> Get(bool lazzLoader = false);
        IEnumerable<DTO.Cliente> Get(Expression<Func<DTO.Cliente, bool>> where, bool lazzLoader = false);

    }
}
