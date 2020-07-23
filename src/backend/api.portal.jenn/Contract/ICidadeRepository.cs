using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface ICidadeRepository
    {
        DTO.Cidade Insert(DTO.Cidade model,  int EmpresaID);
        IEnumerable<DTO.Cidade> Get(int EmpresaID);
        void Delete(int CidadeID);
        void Update(DTO.Cidade model, int CidadeID, int EmpresaID);
        DTO.Cidade Detail( int EmpresaID, int CidadeID);
    }
}
