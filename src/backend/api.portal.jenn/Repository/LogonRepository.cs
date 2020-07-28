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
    public class LogonRepository : IDisposable, ILogonRepository
    {

        private readonly LogonContextFactory contexto;
        private readonly ILogger<LogonRepository> logger;
        private readonly IConfiguration configuration;


        public LogonRepository(
            IConfiguration _configuration,
            ILogger<LogonRepository> _logger,
            LogonContextFactory _context)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.contexto = _context;
        }

        public Logon Detail(Expression<Func<Logon, bool>> where)
        {
           
                Logon retorno = null;
                try
                {
                    using (var ctx = contexto.CreateDbContext(null))
                    { 
                        retorno = ctx.Logon.Include(c=> c.Papeis).Where(where).SingleOrDefault();
                    }
                }
                catch (Exception exception)
                {
                    this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                    throw;
                }
                return retorno;
           
        }

        public async Task<Logon> DetailAsync(Expression<Func<Logon, bool>> where)
        {

            Logon retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                    retorno = await ctx.Logon.Include(c => c.Papeis).Where(where).FirstOrDefaultAsync();
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

        public Logon Insert(Logon model, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Logon Insert(Logon model)
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

        public void Update(Logon model, int id)
        {
            throw new NotImplementedException();
        }
    }

}
