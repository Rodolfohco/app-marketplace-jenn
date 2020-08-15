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
    public class ClienteRepository: IClienteRepository
    {
        private readonly ClienteContextFactory contexto;
        private readonly ILogger<ClienteRepository> logger;
        private readonly IConfiguration configuration;
        public ClienteRepository(
            IConfiguration _configuration,
            ILogger<ClienteRepository> _logger,
            ClienteContextFactory _context)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.contexto = _context;
        }

        public void Delete(Expression<Func<Contato, bool>> where)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = ctx.Contato.Where(where).FirstOrDefault();
                    if (item != null)
                        ctx.Contato.Remove(item);

                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.InnerException}] ;", exception);
                throw;
            }
        }
        public void Delete(Expression<Func<Cliente, bool>> where)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
            {
                var item = ctx.Clientes.Where(where).FirstOrDefault();
                if (item != null)
                    ctx.Clientes.Remove(item);

                ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.InnerException}] ;", exception);
                throw;
            }
        }

        public Contato Detail(Expression<Func<Contato, bool>> where, bool lazzLoader = false)
        {
            Contato retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                        retorno = ctx.Contato.Where(where).SingleOrDefault();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public Cliente Detail(Expression<Func<Cliente, bool>> where, bool lazzLoader = false)
        {
            Cliente retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    retorno = ctx.Clientes.Where(where).SingleOrDefault();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Contato> Get(Expression<Func<Contato, bool>> where, bool lazzLoader = false)
        {
            List<Contato> retorno = new List<Contato>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    ctx.Contato.AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Cliente> Get(bool lazzLoader = false)
        {
            List<Cliente> retorno = new List<Cliente>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                    {
                        ctx.Clientes
                            .Include(c => c.Usuario)
                            .Include(c => c.Avaliacao)
                            .AsParallel().ForAll(item => { retorno.Add(item); });
                    }
                    else
                        ctx.Clientes.AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Cliente> Get(Expression<Func<Cliente, bool>> where, bool lazzLoader = false)
        {
            List<Cliente> retorno = new List<Cliente>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                    {
                        ctx.Clientes.Where(where)
                            .Include(c => c.Usuario)
                            .Include(c => c.Avaliacao)
                            .AsParallel().ForAll(item => { retorno.Add(item); });
                    }
                    else
                        ctx.Clientes.Where(where).AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Contato> GetContato(bool lazzLoader = false)
        {
            List<Contato> retorno = new List<Contato>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    ctx.Contato.AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public Contato Insert(Contato model)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    ctx.Contato.Add(model);
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

        public Cliente Insert(Cliente model)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    ctx.Clientes.Add(model);
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
    }
}
