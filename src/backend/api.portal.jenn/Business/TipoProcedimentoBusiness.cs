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
    public class TipoProcedimentoBusiness : ITipoProcedimentoBusiness
    {

        private readonly ITipoProcedimentoRepository repository;
        private readonly ILogger<TipoProcedimentoBusiness> _logger;
        private readonly IMapper mapper;

        public TipoProcedimentoBusiness(
            ILogger<TipoProcedimentoBusiness> logger,
            ITipoProcedimentoRepository _repository,

             IMapper _mapper)
        {

            this.mapper = _mapper;
            this.repository = _repository;
            this._logger = logger;
        }


        public void Atualizar(TipoProcedimentoViewModel model, int id)
        {
            try
            {
                this.repository.Update(
                   this.mapper.Map<ViewModel.TipoProcedimentoViewModel, DTO.TipoProcedimento>(model), id);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.Message}] ;", exception);
            }
        }

        public TipoProcedimentoViewModel Detalhar(Expression<Func<TipoProcedimento, bool>> where)
        {
            TipoProcedimento retorno = null;
            try
            {
                retorno = this.repository.Detail(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
            }
            return this.mapper.Map<DTO.TipoProcedimento, ViewModel.TipoProcedimentoViewModel>(retorno);
        }

        public void Excluir(Expression<Func<TipoProcedimento, bool>> where)
        {
            try
            {
                this.repository.Delete(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.Message}] ;", exception);
            }
        }

        public TipoProcedimentoViewModel Inserir(TipoProcedimentoViewModel model)
        {
            TipoProcedimento retorno = null;
            try
            {
                var TipoProcedimento = this.mapper.Map<ViewModel.TipoProcedimentoViewModel, DTO.TipoProcedimento>(model);
                retorno = this.repository.Insert(TipoProcedimento);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.TipoProcedimento, ViewModel.TipoProcedimentoViewModel>(retorno);
        }

        public IEnumerable<TipoProcedimentoViewModel> Selecionar()
        {
            IEnumerable<TipoProcedimento> retorno = Enumerable.Empty<TipoProcedimento>();
            try
            {
                retorno = this.repository.Get(true);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.TipoProcedimento>, IEnumerable<ViewModel.TipoProcedimentoViewModel>>(retorno);
        }

        public IEnumerable<TipoProcedimentoViewModel> Selecionar(Expression<Func<TipoProcedimento, bool>> where)
        {
            IEnumerable<TipoProcedimento> retorno = Enumerable.Empty<TipoProcedimento>();
            try
            {
                retorno = this.repository.Get(where,true);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.TipoProcedimento>, IEnumerable<ViewModel.TipoProcedimentoViewModel>>(retorno);
        }
    }
}
