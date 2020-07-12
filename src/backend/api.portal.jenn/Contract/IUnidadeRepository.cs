using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace api.portal.jenn.Contract
{
    public interface IUnidadeRepository
    {

        DTO.Unidade Insert(DTO.Unidade model, Guid EmpresaID);
        IEnumerable<DTO.Unidade> Get(Guid EmpresaID );
        void Delete(Guid EmpresaID, Guid UnidadeID);
        void Update(DTO.Unidade model, Guid UnidadeID, Guid EmpresaID);
        DTO.Unidade Detail(Guid UnidadeID, Guid EmpresaID);


        void InicializarBanco();

    }

}
