using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        readonly ILogger<ProdutoRepository>  logger;
      

        readonly EmpresaContextFactory contexto;
        public ProdutoRepository( 
            EmpresaContextFactory _contextFactory, 
            ILogger<ProdutoRepository> _logger)
        {
            this.contexto = _contextFactory;
            this.logger = _logger;
        }
        public void Delete(Guid ProdutoID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(ProdutoID);
                    if (item != null)
                    {
                        ctx.Produtos.Remove(item);
                        ctx.SaveChanges();
                    }
                    else
                        throw new Exception($"Registro não localizado [{ProdutoID}]");
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.Message}] ;", exception);
                throw;
            }
        }

        public Produto Detail(Guid ProdutoID, bool lazzLoader = false)
        {
            Produto retorno = null;
            try
            {

                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        retorno = ctx.Produtos.Include(c => c.UnidadeProdutos).Where(c=> c.ProdutoID == ProdutoID).SingleOrDefault();
                    else
                        retorno = ctx.Produtos.Where(c => c.ProdutoID == ProdutoID).SingleOrDefault();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Produto> Get(Guid UnidadeID, bool lazzLoader = false)
        {
            List<Produto> retorno = new List<Produto>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        ctx.Unidades.Where(x=>x.UnidadeID == UnidadeID).Include(c => c.Produtos).AsParallel().ForAll(item => { retorno.AddRange(item.Produtos.ToArray()); });
                    else
                        ctx.Produtos.AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Produto> GetAll(bool lazzLoader = false)
        {
            List<Produto> retorno = new List<Produto>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                        ctx.Unidades.Include(c => c.Produtos).AsParallel().ForAll(item => { retorno.AddRange(item.Produtos.ToArray()); });
                    else
                        ctx.Produtos.AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public Produto Insert(Produto model, Guid UnidadeID, Guid EmpresaID)
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

        public void Update(Produto model, Guid ProdutoID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = ctx.Produtos.Where(x => x.ProdutoID == ProdutoID).SingleOrDefault();
                    if (item != null)
                    {
                        model.Unidade = item.Unidade;

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
