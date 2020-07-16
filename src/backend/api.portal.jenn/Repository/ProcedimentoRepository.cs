using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.factory;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Repository
{
    public class ProcedimentoRepository : IProcedimentoRepository
    {
        private readonly ProcedimentoContextFactory contexto;
        private readonly ILogger<ProcedimentoRepository> logger;
        private readonly IConfiguration configuration;
        public ProcedimentoRepository(
            IConfiguration _configuration,
            ILogger<ProcedimentoRepository> _logger,
            ProcedimentoContextFactory _context)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.contexto = _context;
        }



        public void Delete(Expression<Func<Procedimento, bool>> where)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(where);
                    if (item != null)
                        ctx.Procedimento.Remove(item);
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.Message}] ;", exception);
                throw;
            }
        }

        public virtual Procedimento Detail(Expression<Func<Procedimento, bool>> where, bool lazzLoader = false)
        {
            Procedimento retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                        retorno = ctx.Procedimento.Where(where).SingleOrDefault();
                
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
            }
            finally
            {

            }
        }

        public virtual IEnumerable<Procedimento> Get(bool lazzLoader = false)
        {
            List<Procedimento> retorno = new List<Procedimento>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                        ctx.Procedimento.AsParallel().ForAll(item => { retorno.Add(item); });
               
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public virtual IEnumerable<Procedimento> Get(Expression<Func<Procedimento, bool>> where, bool lazzLoader = false)
        {
            List<Procedimento> retorno = new List<Procedimento>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                        ctx.Procedimento.Where(where).AsParallel().ForAll(item => { retorno.Add(item); });
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }




        public virtual Procedimento Insert(Procedimento model)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    ctx.Add(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.Message}] ;", exception);
                throw;
            }
            return model;
        }

        public virtual void Update(Procedimento model, Guid id)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(c => c.ProcedimentiID == id);
                    if (item != null)
                    {
                        model.ProcedimentiID = id;
                        ctx.Update(model);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Update] [{exception.Message}] ;", exception);
                throw;
            }
        }
         
    }
}
 