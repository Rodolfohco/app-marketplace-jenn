using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.Mapeamento;
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
    public class ConvenioBusiness : IConvenioBusiness
    {
        private readonly IConvenioRepository repository;
        private readonly ILogger<ConvenioBusiness> _logger;
        private readonly IMapper mapper;

        public ConvenioBusiness(
            ILogger<ConvenioBusiness> logger,
            IConvenioRepository _repository,
             IMapper _mapper)
        {
            this.mapper = _mapper;
            this.repository = _repository;
            this._logger = logger;
        }

      
        public void Atualizar(ConvenioViewModel model, int id)
        {
            try
            {
                this.repository.Update(
                   this.mapper.Map<ViewModel.ConvenioViewModel, DTO.Convenio>(model), id);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.InnerException}] ;", exception);
            }
        }

        public ConvenioViewModel Detalhar(Expression<Func<DTO.Convenio, bool>> where)
        {
            Convenio retorno = null;
            try
            {
                retorno = this.repository.Detail(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.InnerException}] ;", exception);
            }
            return this.mapper.Map<DTO.Convenio, ViewModel.ConvenioViewModel>(retorno);
        }

        public void Excluir(Expression<Func<DTO.Convenio, bool>> where)
        {
            try
            {
                this.repository.Delete(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Excluir] [{exception.InnerException}] ;", exception);
            }

        }

        public ConvenioViewModel Inserir(ConvenioViewModel model)
        {
            Convenio retorno = null;
            try
            {
                var ConvenioNovo = this.mapper.Map< ViewModel.ConvenioViewModel, DTO.Convenio>(model);

                 
                ConvenioNovo.Ativo = DTO.Status.Ativo;
          
            
                ConvenioNovo.DataInclusao = DateTime.Now;
                retorno = this.repository.Insert(ConvenioNovo);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Convenio, ViewModel.ConvenioViewModel>(retorno);
        }

        public IEnumerable<ConvenioViewModel> Selecionar()
        {
            IEnumerable<Convenio> retorno = Enumerable.Empty<Convenio>();
            try
            {
                retorno = this.repository.Get(true);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Convenio>, IEnumerable<ViewModel.ConvenioViewModel>>(retorno);
        }

        public IEnumerable<ConvenioViewModel> Selecionar(Expression<Func<DTO.Convenio, bool>> where)
        {
            IEnumerable<Convenio> retorno = Enumerable.Empty<Convenio>();
            try
            {
                retorno = this.repository.Get(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Convenio>, IEnumerable<ViewModel.ConvenioViewModel>>(retorno);

        }
 
    }

}
