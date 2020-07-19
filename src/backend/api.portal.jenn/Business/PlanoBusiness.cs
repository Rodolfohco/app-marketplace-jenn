using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Business
{
    public class PlanoBusiness : IPlanoBusiness
    {
        private readonly IConvenioRepository repository;
        private readonly ILogger<PlanoBusiness> _logger;
        private readonly IMapper mapper;

        public PlanoBusiness(
            ILogger<PlanoBusiness> logger,
            IConvenioRepository _repository,
             IMapper _mapper)
        {
            this.mapper = _mapper;
            this.repository = _repository;
            this._logger = logger;
        }

        public void Atualizar(PlanoViewModel model, Guid PlanoID, Guid ConvenioID)
        {
            try
            {
                var convenio = this.repository.Detail(c => c.Id == ConvenioID);
                if (convenio != null)
                {
                    var plano = this.mapper.Map<PlanoViewModel, Plano>(model);

                    if (!convenio.Planos.Contains(plano))
                        throw new Exception($"Plano Convenio não Localizado: id do Convenio [{ConvenioID}]  id do Plano [{PlanoID}]");
                    else
                        this.repository.Update(plano, PlanoID,  ConvenioID);
                   
                }
                else
                    throw new Exception($"Convenio não Localizado: id do Convenio [{ConvenioID}]");
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.Message}] ;", exception);
                throw;
            }
        }
        public PlanoViewModel Detalhar(Guid PlanoID, Guid ConvenioID)
        {
            PlanoViewModel retorno = null;
            try
            {
                var convenio = this.repository.Detail(c => c.Id == ConvenioID, true);

                if (convenio != null)
                {
                    var Plano = convenio.Planos.Where(x => x.PlanoID == PlanoID).SingleOrDefault();
                   
                    if (Plano != null)
                        retorno = this.mapper.Map<Plano, PlanoViewModel>(Plano);
                    else
                        throw new Exception($"Plano Convenio não Localizado: id do Convenio [{ConvenioID}]  id do Plano [{PlanoID}]");
                }
                else
                    throw new Exception($"Convenio não Localizado: id do Convenio [{ConvenioID}]  id do Plano [{PlanoID}]");
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public void Excluir(Guid PlanoID, Guid ConvenioID)
        {
            try
            {
                var convenio = this.repository.Detail(c => c.Id == ConvenioID);
                if (convenio != null)
                {
                    var Plano = convenio.Planos.Where(x => x.PlanoID == PlanoID).SingleOrDefault();
                    convenio.Planos.Remove(Plano);

                    this.repository.Update(convenio, ConvenioID);
                }
                else
                    throw new Exception($"Convenio não Localizado: id do Convenio [{ConvenioID}]");
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Excluir] [{exception.Message}] ;", exception);
                throw;
            }
        }

        public PlanoViewModel Inserir(PlanoViewModel model, Guid ConvenioID)
        {
            try
            {
                var convenio = this.repository.Detail(c => c.Id == ConvenioID);
                if (convenio != null)
                {

                    var PlanoNovo = new Plano();

                    PlanoNovo.Convenio = convenio;
                    PlanoNovo.PlanoID = model.PlanoID;
                    PlanoNovo.Nome = model.Nome;

                    this.repository.Insert(PlanoNovo, ConvenioID);
                }
                else
                    throw new Exception($"Convenio não Localizado: id do Convenio [{ConvenioID}]");
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.Message}] ;", exception);
                throw;
            }
            return model;

        }

        public IEnumerable<PlanoViewModel> Selecionar(Guid ConvenioID)
        {
            IEnumerable<PlanoViewModel> retorno = null;
            try
            {
                var convenio = this.repository.Detail(c => c.Id == ConvenioID, true);

                if (convenio != null)
                    retorno = this.mapper.Map<IEnumerable<Plano>, IEnumerable<PlanoViewModel>>(convenio.Planos.AsEnumerable());
                else
                    throw new Exception($"Convenio não Localizado: id do Convenio [{ConvenioID}]");
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<PlanoViewModel> Selecionar()
        {
            IEnumerable<PlanoViewModel> retorno = null;
            try
            {
                var planos = this.repository.Get(true);

                if (planos != null)
                    retorno = this.mapper.Map<IEnumerable<Plano>,
                        IEnumerable<PlanoViewModel>>(planos.SelectMany(c => c.Planos).AsEnumerable());
                else
                    throw new Exception($"Plano não Localizado");
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
                throw;
            }
            return retorno;
        }
    }
}
