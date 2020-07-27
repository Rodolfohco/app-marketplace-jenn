using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Repository
{
    public class CidadeRepository : ICidadeRepository
    {

        private readonly ConvenioContextFactory contexto;
        private readonly ILogger<CidadeRepository> logger;
        private readonly IConfiguration configuration;
        public CidadeRepository(
            IConfiguration _configuration,
            ILogger<CidadeRepository> _logger,
            ConvenioContextFactory _context)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.contexto = _context;
        }

        public void Delete(int CidadeID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(CidadeID);
                    if (item != null)
                        ctx.Cidades.Remove(item);
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.Message}] ;", exception);
                throw;
            }
        }

        public Cidade Detail(int CidadeID, bool lazzLoader = false)
        {
            Cidade retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        retorno = ctx.Cidades.Include(c => c.Regiao).Include(c=> c.Ufs).Where(c=> c.CidadeID == CidadeID).SingleOrDefault();
                    else
                        retorno = ctx.Cidades.Where(c => c.CidadeID == CidadeID).SingleOrDefault();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Cidade> GetCidadeCliente(int ClienteID, bool lazzLoader = false)
        {
            List<Cidade> retorno = new List<Cidade>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        ctx.Cidades.Include(c => c.Ufs).ThenInclude(c=> c.Pais).Include(c=> c.Regiao).AsParallel().ForAll(item => { retorno.Add(item); });
                    else
                        ctx.Cidades.AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Cidade> GetCidadeCliente( bool lazzLoader = false)
        {
            List<Cidade> retorno = new List<Cidade>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        ctx.Cidades.Include(c => c.Ufs).ThenInclude(c => c.Pais).Include(c => c.Regiao).AsParallel().ForAll(item => { retorno.Add(item); });
                    else
                        ctx.Cidades.AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }
    

        public IEnumerable<Cidade> GetCidadeEmpresa(int EmpresaID, bool lazzLoader = false)
        {
            List<Cidade> retorno = new List<Cidade>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        ctx.Empresas.Where(c=> c.EmpresaID==EmpresaID).Select(c=> c.Cidade).Include(c => c.Ufs).ThenInclude(c => c.Pais).Include(c => c.Regiao).AsParallel().ForAll(item => { retorno.Add(item); });
                    else
                        ctx.Empresas.Where(c => c.EmpresaID == EmpresaID).Select(c => c.Cidade).AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }
    

        public IEnumerable<Cidade> GetCidadeEmpresa( bool lazzLoader = false)
        {
            List<Cidade> retorno = new List<Cidade>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        ctx.Cidades.Include(c => c.Ufs).ThenInclude(c => c.Pais).Include(c => c.Regiao).AsParallel().ForAll(item => { retorno.Add(item); });
                    else
                        ctx.Cidades.AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public Cidade InsertCidade(Cidade model)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    ctx.Cidades.Add(model);
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

        public Cidade InsertCidadeCliente(Cidade model, int ClienteID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var empresa =   ctx.Empresas.Where(c => c.EmpresaID == ClienteID).SingleOrDefault();
                    empresa.Cidade = model;
                    ctx.Entry(empresa).State = EntityState.Modified;

                    ctx.Empresas.Update(empresa);
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

        public Cidade InsertCidadeEmpresa(Cidade model, int EmpresaID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var empresa = ctx.Empresas.Where(c => c.EmpresaID == EmpresaID).SingleOrDefault();
                    empresa.Cidade = model;
                    ctx.Entry(empresa).State = EntityState.Modified;

                    ctx.Empresas.Update(empresa);
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

        public void UpdateCidadeCliente(Cidade model, int CidadeID, int ClienteID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(CidadeID);
                    if (item != null)
                    {

                        model.CidadeID = CidadeID;

                        ctx.Entry(item).State = EntityState.Modified;

                      


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

        public void UpdateCidadeEmpresa(Cidade model, int CidadeID, int EmpresaID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(CidadeID);
                    if (item != null)                   {
                        model.CidadeID = CidadeID;
                        ctx.Entry(item).State = EntityState.Modified;
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

        public int VincularCidadeCliente(int CidadeID, int ClienteID)
        {
            var retorno = 0;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(CidadeID);
                    if (item != null)
                    {
                        var clie = ctx.Clientes.Where(c => c.ClienteID == ClienteID).SingleOrDefault();
                        if (clie != null)
                        {
                            ctx.Entry(clie).State = EntityState.Modified;
                            clie.Cidade = item;
                            ctx.Clientes.Update(clie);
                            retorno = ctx.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Update] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }
        public int VincularCidadeEmpresa(int CidadeID, int EmpresaID)
        {
            var retorno = 0;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(CidadeID);
                    if (item != null)
                    {
                        var emp = ctx.Empresas.Where(c => c.EmpresaID == EmpresaID).SingleOrDefault();
                        if (emp != null)
                        {
                            ctx.Entry(emp).State = EntityState.Modified;
                            emp.Cidade = item;
                            ctx.Empresas.Update(emp);
                            retorno = ctx.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Update] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }
    }
}
