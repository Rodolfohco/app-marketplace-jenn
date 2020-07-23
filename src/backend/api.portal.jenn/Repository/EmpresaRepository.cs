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
    public class EmpresaRepository: IEmpresaRepository
    {
        private readonly EmpresaContextFactory contexto;
        private readonly ILogger<EmpresaRepository> logger;
        private readonly IConfiguration configuration;


        public EmpresaRepository(
            IConfiguration _configuration,
            ILogger<EmpresaRepository> _logger,
            EmpresaContextFactory _context)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.contexto = _context;
        }

        public void Delete(Expression<Func<Empresa, bool>> where)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
   
                    var item = Detail(where);
                    if (item != null)
                        ctx.Empresas.Remove(item);
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.Message}] ;", exception);
                throw;
            }
        }

        public Empresa Detail(Expression<Func<Empresa, bool>> where, bool lazzLoader = false)
        {
            Empresa retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                    {
                        retorno = ctx.Empresas
                            .Include(c => c.ProcedimentoEmpresas)
                           .ThenInclude(c => c.Procedimento)
                           .ThenInclude(c => c.TipoProcedimento)
                           .ThenInclude(c => c.Categoria)
                           .Include(c => c.Cidades)
                           .ThenInclude(c => c.Regiao)
                           .Include(c => c.Cidades)
                           .ThenInclude(c => c.Ufs).Where(where).SingleOrDefault();
                    }
                    else
                        retorno = ctx.Empresas.Where(where).SingleOrDefault();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }



        public IEnumerable<Empresa> Get(bool lazzLoader = false)
        {
            List<Empresa> retorno = new List<Empresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    if (lazzLoader)
                    {
                        ctx.Empresas.Include(c => c.ProcedimentoEmpresas)
                            .ThenInclude(c => c.Procedimento)
                            .ThenInclude(c => c.TipoProcedimento)
                            .ThenInclude(c => c.Categoria)
                            .Include(c => c.Cidades)
                            .ThenInclude(c => c.Regiao)
                            .Include(c => c.Cidades)
                            .ThenInclude(c => c.Ufs)
                                .AsParallel().ForAll(
                            item =>
                            {
                                retorno.Add(item);
                            });
                    }
                    else
                    {
                        ctx.Empresas.Include(c => c.ProcedimentoEmpresas)
                           .ThenInclude(c => c.Procedimento)
                           .ThenInclude(c => c.TipoProcedimento)
                           .ThenInclude(c => c.Categoria)
                           .Include(c => c.Cidades)
                           .ThenInclude(c => c.Regiao)
                           .Include(c => c.Cidades)
                           .ThenInclude(c => c.Ufs)
                               .AsParallel().ForAll(
                           item =>
                           {
                               retorno.Add(item);
                           });
                    }
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

 
        public IEnumerable<Empresa> Get(Expression<Func<Empresa, bool>> where, bool lazzLoader = false)
        {
            List<Empresa> retorno = new List<Empresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                               ctx.Empresas.Where(where).AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Empresa> GetFiliais(bool lazzLoader = false)
        {
            List<Empresa> retorno = new List<Empresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                        ctx.Empresas.SelectMany(c=> c.Filiais)
                            .Include(c=> c.Cidades)
                            .ThenInclude(c=> c.Ufs)
                            .Include(c=> c.ProcedimentoEmpresas)
                            .ThenInclude(c => c.Procedimento)
                            .ThenInclude(c=> c.TipoProcedimento)
                            .Include(c=> c.Fotos)
                            .AsParallel().ForAll(
                            item =>
                            {
                                retorno.Add(item);
                            });
                   
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<ProcedimentoEmpresa> GetProcedimentoEmpresa(int EmpresaID)
        {
            List<ProcedimentoEmpresa> retorno = new List<ProcedimentoEmpresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    ctx.Empresas.Where(c => c.EmpresaID == EmpresaID).Include(c => c.ProcedimentoEmpresas)
                        .Select(c => c.ProcedimentoEmpresas).AsParallel().ForAll(
                        item =>
                        {
                            retorno.AddRange(item.ToArray());
                        });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<ProcedimentoEmpresa> GetProcedimentoEmpresa()
        {
            List<ProcedimentoEmpresa> retorno = new List<ProcedimentoEmpresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    ctx.ProcedimentoEmpresa
                        .Include(x => x.Procedimento)
                        .ThenInclude(p => p.TipoProcedimento)
                        .Include(c => c.Empresa)
                        .ThenInclude(x => x.Cidades)
                        .AsParallel().ForAll(
                        item =>
                        {
                            retorno.Add(item);
                        });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }


        public Empresa Insert(Empresa model)
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

        public ProcedimentoEmpresa Insert(ProcedimentoEmpresa model, int EmpresaID, int ProcedimentoID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    model.EmpresaID = EmpresaID;
                    model.ProcedimentoID = ProcedimentoID;
                    ctx.Add(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Update] [{exception.Message}] ;", exception);
                throw;
            }
            return model;
        }
        public void Update(Empresa model, int id)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(c => c.EmpresaID == id);
                    if (item != null)
                    {
                        model.EmpresaID = id;

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
