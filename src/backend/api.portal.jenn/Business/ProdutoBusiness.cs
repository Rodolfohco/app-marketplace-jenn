using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.factory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Business
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private readonly ILogger<ProdutoBusiness> logger;
        private readonly IProdutoRepository repository;


        public ProdutoBusiness(ILogger<ProdutoBusiness> _logger, IProdutoRepository _repository)
        {
            this.logger = _logger;
            this.repository = _repository;
        }


        public void Atualizar(Produto model, Guid id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public Produto Detalhar(Expression<Func<Produto, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Expression<Func<Produto, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Produto Inserir(Produto model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Selecionar()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Selecionar(Expression<Func<Produto, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
