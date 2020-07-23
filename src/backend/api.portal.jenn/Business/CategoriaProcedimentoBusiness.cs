using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.portal.jenn.Business
{
    public class CategoriaProcedimentoBusiness : ICategoriaProcedimentoBusiness
    {
        private readonly IConvenioRepository repository;
        private readonly ILogger<CategoriaProcedimentoBusiness> _logger;
        private readonly IMapper mapper;

        public CategoriaProcedimentoBusiness(
            ILogger<CategoriaProcedimentoBusiness> logger,
            IConvenioRepository _repository,
             IMapper _mapper)
        {
            this.mapper = _mapper;
            this.repository = _repository;
            this._logger = logger;
        }
        public void Atualizar(CategoriaViewModel model, int id)
        {
            throw new NotImplementedException();
        }

        public CategoriaViewModel Detalhar(Expression<Func<CategoriaProcedimento, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Expression<Func<CategoriaProcedimento, bool>> where)
        {
            throw new NotImplementedException();
        }

        public CategoriaViewModel Inserir(CategoriaViewModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaViewModel> Selecionar()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaViewModel> Selecionar(Expression<Func<CategoriaProcedimento, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
