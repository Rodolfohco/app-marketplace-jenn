using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface ICidadeRepository
    {
        DTO.Cidade Insert(DTO.Cidade model,  Guid EmpresaID);
        IEnumerable<DTO.Cidade> Get(Guid EmpresaID);
        void Delete(Guid CidadeID);
        void Update(DTO.Cidade model, Guid CidadeID, Guid EmpresaID);
        DTO.Cidade Detail( Guid EmpresaID, Guid CidadeID);
    }
}
