using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.factory;
using Castle.DynamicProxy.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Repository
{
    public class UnidadeRepository: IUnidadeRepository
    {
      
            private readonly EmpresaContextFactory contexto;
            private readonly ILogger<UnidadeRepository> logger;
            private readonly IConfiguration configuration;


            public UnidadeRepository(
                IConfiguration _configuration,
                ILogger<UnidadeRepository> _logger,
                EmpresaContextFactory _context)
            {
                this.configuration = _configuration;
                this.logger = _logger;
                this.contexto = _context;
            }

        public void Delete(Guid EmpresaID, Guid UnidadeID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = ctx.Empresas.Where(c => c.EmpresaID == EmpresaID).SingleOrDefault();
                    if (item != null)
                    {
                        var unidade = item.Unidade.Where(x => x.UnidadeID == UnidadeID).SingleOrDefault();

                        if (unidade != null)
                        {
                            item.Unidade.Remove(unidade);
                            ctx.SaveChanges();
                        }
                        else
                            throw new Exception($"Unidade não Localizada [{UnidadeID}]");
                    }
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.Message}] ;", exception);
                throw;
            }

        }

        public Unidade Detail(Guid UnidadeID, Guid EmpresaID)
        {
            Unidade retorno = null;
            try
            {

                using (var ctx = contexto.CreateDbContext(null))
                {
                    retorno = ctx.Empresas
                        .Include(c => c.Unidade)
                        .Where(c => c.EmpresaID == EmpresaID)
                        .SelectMany(i => i.Unidade)
                        .Where(x => x.UnidadeID == UnidadeID).SingleOrDefault();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Unidade> Get(Guid EmpresaID)
        {
            this.InicializarBanco();

            List<Unidade> retorno = new List<Unidade>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    ctx.Empresas.Include(c => c.Unidade).Where(x=> x.EmpresaID == EmpresaID).SelectMany(x=> x.Unidade).AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public void InicializarBanco()
        {
            using (var ctx = contexto.CreateDbContext(null))
            {
                ctx.Database.Migrate();
            }
        }

        public Unidade Insert(Unidade model, Guid EmpresaID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var empresa = ctx.Empresas.Where(x => x.EmpresaID == EmpresaID).SingleOrDefault();
                    if (empresa != null)
                    {
                        model.Empresa = empresa;
                        ctx.Update(model);
                        ctx.SaveChanges();
                    }
                    else
                        throw new Exception($"Empresa não Localizada [{EmpresaID}]");
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.Message}] ;", exception);
                throw;
            }
            return model;
        }

        public void Update(Unidade model, Guid UnidadeID, Guid EmpresaID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var empresa = ctx.Empresas.Where(x => x.EmpresaID == EmpresaID).SingleOrDefault();
                    if (empresa != null)
                    {
                        model.Empresa = empresa;
                        ctx.Update(model);
                        ctx.SaveChanges();
                    }
                    else
                        throw new Exception($"Empresa não Localizada [{EmpresaID}]");
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
