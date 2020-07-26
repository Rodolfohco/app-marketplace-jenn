using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
    public interface ICidadeRepository
    {

        DTO.Cidade InsertCidadeCliente(DTO.Cidade model, int ClienteID);
        DTO.Cidade InsertCidadeEmpresa(DTO.Cidade model, int EmpresaID);

        IEnumerable<DTO.Cidade> GetCidadeCliente(int ClienteID, bool lazzLoader = false);
        IEnumerable<DTO.Cidade> GetCidadeEmpresa(int EmpresaID, bool lazzLoader = false);

        IEnumerable<DTO.Cidade> GetCidadeCliente(bool lazzLoader = false);
        IEnumerable<DTO.Cidade> GetCidadeEmpresa(bool lazzLoader = false);


        void UpdateCidadeCliente(DTO.Cidade model, int CidadeID, int ClienteID);
        void UpdateCidadeEmpresa(DTO.Cidade model, int CidadeID, int EmpresaID);

        DTO.Cidade Detail( int CidadeID, bool lazzLoader = false);
        

        void Delete(int CidadeID);
     
    }
}
