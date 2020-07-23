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

namespace api.portal.jenn.Repository
{
    public class LogonRepository : IDisposable, ILogonRepository
    {
        public void Delete(Expression<Func<Logon, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Logon Detail(Expression<Func<Logon, bool>> where)
        {
            throw new NotImplementedException();
        }

        //private readonly LogonContextFactory contexto;
        //private readonly ILogger<LogonRepository> logger;
        //private readonly IConfiguration configuration;


        //public LogonRepository(
        //    IConfiguration _configuration,
        //    ILogger<LogonRepository> _logger,
        //    LogonContextFactory _context)
        //{
        //    this.configuration = _configuration;
        //    this.logger = _logger;
        //    this.contexto = _context;
        //}

        //public void Delete(Expression<Func<Logon, bool>> where)
        //{
        //    try
        //    {
        //        using (var ctx = contexto.CreateDbContext(null))
        //        {
        //            var item = Detail(where);
        //            if (item != null)
        //                ctx.logons.Remove(item);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.Message}] ;", exception);
        //        throw ;
        //    }
        //}

        //public virtual Logon Detail(Expression<Func<Logon, bool>> where)
        //{
        //    Logon retorno = null;
        //    try
        //    {
        //        using (var ctx = contexto.CreateDbContext(null))
        //        {
        //            retorno = ctx.logons.Where(where).SingleOrDefault();
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
        //        throw;
        //    }
        //    return retorno;
        //}

        //public void Dispose()
        //{
        //    try
        //    {
        //        GC.SuppressFinalize(this);
        //    }
        //    finally
        //    {

        //    }
        //}

        //public virtual IEnumerable<Logon> Get()
        //{
        //    List<Logon> retorno = new List<Logon>();
        //    try
        //    {
        //        using (var ctx = contexto.CreateDbContext(null))
        //        {

        //            ctx.logons.AsParallel().ForAll(item =>
        //            {
        //                retorno.Add(item);
        //            });

        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
        //        throw;
        //    }
        //    return retorno;

        //}

        //public virtual IEnumerable<Logon> Get(Expression<Func<Logon, bool>> where)
        //{
        //    List<Logon> retorno = new List<Logon>();
        //    try
        //    {
        //        using (var ctx = contexto.CreateDbContext(null))
        //        {

        //            ctx.logons.Where(where).AsParallel().ForAll(item =>
        //            {
        //                retorno.Add(item);
        //            });

        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
        //        throw;
        //    }
        //    return retorno;
        //}

        //public void Iniciar()
        //{
        //    using (var ctx = contexto.CreateDbContext(null))
        //    {
        //        ctx.Database.Migrate();
        //    }
        //}

        //public virtual Logon Insert(Logon model)
        //{
        //    try
        //    {
        //        using (var ctx = contexto.CreateDbContext(null))
        //        {
        //            ctx.Add(model);
        //            ctx.SaveChanges();
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.Message}] ;", exception);
        //        throw;
        //    }
        //    return model;
        //}

        //public virtual void Update(Logon model, int id)
        //{
        //    try
        //    {
        //        using (var ctx = contexto.CreateDbContext(null))
        //        {
        //            var item = Detail(c => c.Id == id);
        //            if (item != null)
        //            {
        //                ctx.Update(item);
        //                ctx.SaveChanges();
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        this.logger.LogError($"Ocorreu um erro no metodo [Update] [{exception.Message}] ;", exception);
        //        throw;
        //    }
        //}
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Logon> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Logon> Get(Expression<Func<Logon, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Iniciar()
        {
            throw new NotImplementedException();
        }

        public Logon Insert(Logon model)
        {
            throw new NotImplementedException();
        }

        public void Update(Logon model, int id)
        {
            throw new NotImplementedException();
        }
    }

}
