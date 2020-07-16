using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Contract
{
 

    public interface IConvenioRepository
    {
        /// <summary>
        /// Metodo Cria e recria as tabelas do banco 
        /// </summary>
        DTO.Convenio Insert(DTO.Convenio model);
        IEnumerable<DTO.Convenio> Get(bool lazzLoader =false);
        IEnumerable<DTO.Convenio> Get(Expression<Func<DTO.Convenio, bool>> where, bool lazzLoader = false);
        DTO.Convenio Detail(Expression<Func<DTO.Convenio, bool>> where, bool lazzLoader = false);
        void Delete(Expression<Func<DTO.Convenio, bool>> where);
        void Update(DTO.Convenio model, Guid id);



        #region Metodos
        DTO.Plano  Insert(DTO.Plano model, Guid ConvenioID);
        IEnumerable<DTO.Plano> Get(Guid ConvenioID);
        void Delete(Guid PlanoID, Guid ConvenioID);
        void Update(DTO.Plano model, Guid PlanoID, Guid ConvenioID);
        DTO.Plano Detail(Guid PlanoID, Guid ConvenioID);
        #endregion

    }
}
