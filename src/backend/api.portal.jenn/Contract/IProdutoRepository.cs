using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
   public interface IProdutoRepository
    {

        
        IEnumerable<DTO.Produto> GetAll(bool lazzLoader = false);
        DTO.Produto Insert(DTO.Produto model, Guid UnidadeID, Guid EmpresaID);
        IEnumerable<DTO.Produto> Get(Guid UnidadeID, bool lazzLoader = false);
        void Delete(Guid ProdutoID);
        void Update(DTO.Produto model, Guid ProdutoID);
        DTO.Produto Detail(Guid ProdutoID, bool lazzLoader = false);
    }
}
