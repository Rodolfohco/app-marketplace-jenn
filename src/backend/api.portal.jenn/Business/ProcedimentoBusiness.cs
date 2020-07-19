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
    public class ProcedimentoBusiness : IProcedimentoBusiness
    {

       
        private readonly IProcedimentoRepository repository;
        private readonly ILogger<ProcedimentoBusiness> _logger;
        private readonly IMapper mapper;

        public ProcedimentoBusiness(
            ILogger<ProcedimentoBusiness> logger,
            IProcedimentoRepository _repository,
             IMapper _mapper)
        {
            this.mapper = _mapper;
            this.repository = _repository;
            this._logger = logger;
        }


        public void Atualizar(ProcedimentoViewModel model, Guid id)
        {
            try
            {
                this.repository.Update(
                   this.mapper.Map<ViewModel.ProcedimentoViewModel, DTO.Procedimento>(model), id);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.Message}] ;", exception);
            }
        }

        public ProcedimentoViewModel Detalhar(Expression<Func<Procedimento, bool>> where)
        {
            Procedimento retorno = null;
            try
            {
                retorno = this.repository.Detail(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
            }
            return this.mapper.Map<DTO.Procedimento, ViewModel.ProcedimentoViewModel>(retorno);
        }

        public void Excluir(Expression<Func<Procedimento, bool>> where)
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

        public ProcedimentoViewModel Inserir(ProcedimentoViewModel model)
        {
            Procedimento retorno = null;
            try
            {
                var EmpresaNova = this.mapper.Map<ViewModel.ProcedimentoViewModel, DTO.Procedimento>(model);
                retorno = this.repository.Insert(EmpresaNova);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Procedimento, ViewModel.ProcedimentoViewModel>(retorno);
        }

       

        public IEnumerable<ProcedimentoViewModel> Selecionar()
        {
            IEnumerable<Procedimento> retorno = Enumerable.Empty<Procedimento>();
            try
            {
                retorno = this.repository.Get();
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Procedimento>, IEnumerable<ViewModel.ProcedimentoViewModel>>(retorno);
        }

        public IEnumerable<ProcedimentoViewModel> Selecionar(Expression<Func<Procedimento, bool>> where)
        {
            IEnumerable<Procedimento> retorno = Enumerable.Empty<Procedimento>();
            try
            {
                retorno = this.repository.Get(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Procedimento>, IEnumerable<ViewModel.ProcedimentoViewModel>>(retorno);
        }
    }
}
