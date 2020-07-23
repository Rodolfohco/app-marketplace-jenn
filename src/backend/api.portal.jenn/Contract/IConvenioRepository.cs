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
        void Update(DTO.Convenio model, int id);



        #region Metodos
        DTO.Plano  Insert(DTO.Plano model, int ConvenioID);
        IEnumerable<DTO.Plano> Get(int ConvenioID);
        void Delete(int PlanoID, int ConvenioID);
        void Update(DTO.Plano model, int PlanoID, int ConvenioID);
        DTO.Plano Detail(int PlanoID, int ConvenioID);
        #endregion

    }
}
