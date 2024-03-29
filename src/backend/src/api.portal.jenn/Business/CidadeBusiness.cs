﻿using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.Mapeamento;
using api.portal.jenn.Repository;
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
    public class CidadeBusiness : ICidadeBusiness
    {
        private readonly ICidadeRepository repository;
        private readonly ILogger<CidadeBusiness> _logger;
        private readonly IMapper mapper;

        public CidadeBusiness(ILogger<CidadeBusiness> logger, ICidadeRepository _repository, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.repository = _repository;
            this._logger = logger;
        }

        public void AtualizarCidadeCliente(CidadeViewModel model, int ClienteID )
        {
            try
            {
                this.repository.UpdateCidadeCliente(
                   this.mapper.Map<ViewModel.CidadeViewModel, DTO.Cidade>(model),model.CidadeID, ClienteID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.InnerException}] ;", exception);
            }
        }

        public void AtualizarCidadeEmpresa(CidadeViewModel model, int EmpresaId)
        {
            try
            {
                this.repository.UpdateCidadeEmpresa(
                   this.mapper.Map<ViewModel.CidadeViewModel, DTO.Cidade>(model), model.CidadeID, EmpresaId);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.InnerException}] ;", exception);
            }
        }

        public CidadeViewModel Detalhar(Expression<Func<Cidade, bool>> where)
        {
            throw new NotImplementedException();

        }

        public void Excluir(Expression<Func<Cidade, bool>> where)
        {
            throw new NotImplementedException();
        }

        public CidadeViewModel InserirCidade(NovaCidadeViewModel model)
        {
            Cidade retorno = null;
            try
            {
                var NovaCidade = this.mapper.Map<ViewModel.NovaCidadeViewModel, DTO.Cidade>(model);
                retorno = this.repository.InsertCidade(NovaCidade);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Cidade, ViewModel.CidadeViewModel>(retorno);
        }

        public CidadeViewModel InserirCidadeCliente(NovaCidadeViewModel model, int ClienteID)
        {
            Cidade retorno = null;
            try
            {
                var NovaCidade = this.mapper.Map<ViewModel.NovaCidadeViewModel, DTO.Cidade>(model);
                retorno = this.repository.InsertCidadeCliente(NovaCidade, ClienteID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Cidade, ViewModel.CidadeViewModel>(retorno);
        }

        public CidadeViewModel InserirCidadeEmpresa(NovaCidadeViewModel model, int EmpresaID)
        {
            Cidade retorno = null;
            try
            {
                var NovaCidade = this.mapper.Map<ViewModel.NovaCidadeViewModel, DTO.Cidade>(model);
                retorno = this.repository.InsertCidadeEmpresa(NovaCidade, EmpresaID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Cidade, ViewModel.CidadeViewModel>(retorno);
        }

        public IEnumerable<CidadeViewModel> SelecionarCidadeCliente(Expression<Func<Cidade, bool>> where, int ClienteID)
        {
            IEnumerable<Cidade> retorno = Enumerable.Empty<Cidade>();
            try
            {
                retorno = this.repository.GetCidadeCliente(ClienteID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Cidade>, IEnumerable<ViewModel.CidadeViewModel>>(retorno);
        }

        public IEnumerable<CidadeViewModel> SelecionarCidadeCliente()
        {
            IEnumerable<Cidade> retorno = Enumerable.Empty<Cidade>();
            try
            {
                retorno = this.repository.GetCidadeEmpresa();
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Cidade>, IEnumerable<ViewModel.CidadeViewModel>>(retorno);
        }

        public IEnumerable<CidadeViewModel> SelecionarCidadeEmpresa(Expression<Func<Cidade, bool>> where, int EmpresaID)
        {
            IEnumerable<Cidade> retorno = Enumerable.Empty<Cidade>();
            try
            {
                retorno = this.repository.GetCidadeEmpresa(EmpresaID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Cidade>, IEnumerable<ViewModel.CidadeViewModel>>(retorno);
        }

        public IEnumerable<CidadeViewModel> SelecionarCidadeEmpresa()
        {
            IEnumerable<Cidade> retorno = Enumerable.Empty<Cidade>();
            try
            {
                retorno = this.repository.GetCidadeEmpresa(true);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Cidade>, IEnumerable<ViewModel.CidadeViewModel>>(retorno);
        }

        public bool VincularEmpresaCidade(int CidadeID, int EmpresaID)
        {
            var retorno = false;
            try
            {
                retorno = this.repository.VincularCidadeEmpresa(CidadeID, EmpresaID) > 0;
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.InnerException}] ;", exception);
            }
            return retorno;
        }

        public bool VincularClienteCidade(int CidadeID, int ClienteID)
        {
            var retorno = false;
            try
            {
                retorno = this.repository.VincularCidadeCliente(CidadeID, ClienteID) > 0;
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.InnerException}] ;", exception);
            }
            return retorno;
        }
    }
}
