using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.factory;
using api.portal.jenn.ViewModel;
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
    public class ConvenioRepository : IConvenioRepository
    {
        private readonly ConvenioContextFactory contexto;
        private readonly ILogger<ConvenioRepository> logger;
        private readonly IConfiguration configuration;
        public ConvenioRepository(
            IConfiguration _configuration,
            ILogger<ConvenioRepository> _logger,
            ConvenioContextFactory _context)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.contexto = _context;
        }


        public void InicializarBanco()
        {
            using (var ctx = contexto.CreateDbContext(null))
            {
                ctx.Database.Migrate();
            }
        }

        public void Delete(Expression<Func<Convenio, bool>> where)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(where);
                    if (item != null)
                        ctx.Convenios.Remove(item);
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.Message}] ;", exception);
                throw;
            }
        }

        public virtual Convenio Detail(Expression<Func<Convenio, bool>> where, bool lazzLoader = false)
        {
            Convenio retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if(lazzLoader)                
                    retorno = ctx.Convenios.Include(c => c.Planos).Where(where).SingleOrDefault();
                    else
                        retorno = ctx.Convenios.Where(where).SingleOrDefault();
                }
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

        public virtual IEnumerable<Convenio> Get(bool lazzLoader = false)
        {
            List<Convenio> retorno = new List<Convenio>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        ctx.Convenios.Include(c => c.Planos).AsParallel().ForAll(item => { retorno.Add(item); });
                    else
                        ctx.Convenios.AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public virtual IEnumerable<Convenio> Get(Expression<Func<Convenio, bool>> where, bool lazzLoader = false)
        {
            List<Convenio> retorno = new List<Convenio>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        ctx.Convenios.Include(c => c.Planos).Where(where).AsParallel().ForAll(item => { retorno.Add(item); });
                    else
                        ctx.Convenios.Where(where).AsParallel().ForAll(item => { retorno.Add(item); });

                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }



        public void Iniciar()
        {
            using (var ctx = contexto.CreateDbContext(null))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }
        }

        public virtual Convenio Insert(Convenio model)
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

        public virtual void Update(Convenio model, Guid id)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(c => c.Id == id);
                    if (item != null)
                    {
                        model.Id = id;
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

        public  Plano Insert( Plano model, Guid ConvenioID)
        {
             Plano retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var convenio = ctx.Convenios.Where(c => c.Id == ConvenioID).SingleOrDefault();
                    model.Convenio = convenio;

                    ctx.Planos.Add(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Plano> Get(Guid ConvenioID)
        {
            IEnumerable<Plano> retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var convenio = ctx.Convenios.Where(c => c.Id == ConvenioID).SingleOrDefault();
                    retorno = convenio.Planos.AsEnumerable();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public void Delete(Guid ConvenioPlanoID, Guid ConvenioID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var convenio = ctx.Convenios.Where(c => c.Id == ConvenioID).SingleOrDefault();
                    var convenioPlano = convenio.Planos.Where(c => c.PlanoID == ConvenioID).SingleOrDefault();
                    ctx.Planos.Remove(convenioPlano);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                throw;
            }

        }

        public void Update( Plano model, Guid ConvenioPlanoID, Guid ConvenioID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var convenio = ctx.Convenios.Where(c => c.Id == ConvenioID).SingleOrDefault();
                    var convenioPlano = convenio.Planos.Where(c => c.PlanoID == ConvenioID).SingleOrDefault();
                    ctx.Planos.Update(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                throw;
            }
        }

        public  Plano Detail(Guid ConvenioPlanoID, Guid ConvenioID)
        {
             Plano retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var convenio = ctx.Convenios.Where(c=> c.Id == ConvenioID).SingleOrDefault();
                    retorno = convenio.Planos.Where(c => c.PlanoID == ConvenioID).SingleOrDefault();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }
    }
}