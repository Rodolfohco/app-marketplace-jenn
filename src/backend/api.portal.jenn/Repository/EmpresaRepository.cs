﻿using api.portal.jenn.Contract;
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
                        retorno = ctx.Empresas.Include(c => c.ProcedimentoEmpresa).Where(where).SingleOrDefault();
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
                        ctx.Empresas.AsParallel().ForAll(item => { retorno.Add(item); });
                
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

        public IEnumerable<ProcedimentoEmpresa> GetProcedimentoEmpresa(Guid EmpresaID)
        {
            List<ProcedimentoEmpresa> retorno = new List<ProcedimentoEmpresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    ctx.Empresas.Where(c => c.EmpresaID == EmpresaID).Include(c => c.ProcedimentoEmpresa)
                        .Select(c => c.ProcedimentoEmpresa).AsParallel().ForAll(
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

                    ctx.Empresas.Include(c => c.ProcedimentoEmpresa)
                        .Select(c => c.ProcedimentoEmpresa).AsParallel().ForAll(
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

        public ProcedimentoEmpresa Insert(ProcedimentoEmpresa model, Guid EmpresaID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(c => c.EmpresaID == EmpresaID, true);
                    if (item != null)
                    {
                        item.ProcedimentoEmpresa.Add(model);




                        ctx.Update(item);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Update] [{exception.Message}] ;", exception);
                throw;
            }
            return model;
        }

        public void Update(Empresa model, Guid id)
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
