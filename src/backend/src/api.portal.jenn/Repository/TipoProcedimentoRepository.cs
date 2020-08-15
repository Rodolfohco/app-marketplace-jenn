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
    public class TipoProcedimentoRepository : ITipoProcedimentoRepository
    {

        private readonly ConvenioContextFactory contexto;
        private readonly ILogger<TipoProcedimentoRepository> logger;
        private readonly IConfiguration configuration;
        public TipoProcedimentoRepository(
            IConfiguration _configuration,
            ILogger<TipoProcedimentoRepository> _logger,
            ConvenioContextFactory _context)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.contexto = _context;
        }




        public void Delete(Expression<Func<TipoProcedimento, bool>> where)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(where);
                    if (item != null)
                        ctx.TipoProcedimento.Remove(item);
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.InnerException}] ;", exception);
                throw;
            }
        }

        public TipoProcedimento Detail(Expression<Func<TipoProcedimento, bool>> where, bool lazzLoader = false)
        {
            TipoProcedimento retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        retorno = ctx.TipoProcedimento.Include(c => c.Categoria).Where(where).SingleOrDefault();
                    else
                        retorno = ctx.TipoProcedimento.Where(where).SingleOrDefault();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<TipoProcedimento> Get(bool lazzLoader = false)
        {
            List<TipoProcedimento> retorno = new List<TipoProcedimento>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        ctx.TipoProcedimento.Include(c => c.Categoria).AsParallel().ForAll(item => { retorno.Add(item); });
                    else
                        ctx.TipoProcedimento.AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<TipoProcedimento> Get(Expression<Func<TipoProcedimento, bool>> where, bool lazzLoader = false)
        {
            List<TipoProcedimento> retorno = new List<TipoProcedimento>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        ctx.TipoProcedimento.Include(c => c.Categoria).Where(where).AsParallel().ForAll(item => { retorno.Add(item); });
                    else
                        ctx.TipoProcedimento.Where(where).AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public TipoProcedimento Insert(TipoProcedimento model)
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
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.InnerException}] ;", exception);
                throw;
            }
            return model;
        }

        public void Update(TipoProcedimento model, int id)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(c => c.TipoProcedimentoID == id);
                    if (item != null)
                    {
                        model.TipoProcedimentoID = id;
                        ctx.Update(model);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Update] [{exception.InnerException}] ;", exception);
                throw;
            }
        }
    }
}
