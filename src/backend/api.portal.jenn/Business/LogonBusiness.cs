using api.portal.jenn.Contract;
using api.portal.jenn.Utilidade;
using api.portal.jenn.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using api.portal.jenn.DTO;
using Security = api.portal.jenn.Utilidade.Cryptography;
using Microsoft.AspNetCore.Mvc.Formatters;
using api.portal.jenn.Mapeamento;

namespace api.portal.jenn.Business
{
    public class LogonBusiness : ILogonBusiness
    {
        private readonly ILogonRepository repository;
        private readonly ILogger<LogonBusiness> _logger;
        private readonly IMapper mapper;

        public LogonBusiness(
            ILogger<LogonBusiness> logger,
            ILogonRepository _repository,
             IMapper _mapper)
        {
            this.mapper = _mapper;
            this.repository = _repository;
            this._logger = logger;
   
        }

        public void InicializarBanco()
        {
            this.repository.Iniciar();

        }
        public void Atualizar(LogonViewModel model, int id)
        {
            try
            {
                model.Password = Security.ComputeSha256Hash(model.Password);

                this.repository.Update(
                   this.mapper.Map<ViewModel.LogonViewModel, DTO.Logon>(model), id);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.Message}] ;", exception);
            }
        }



        public LogonViewModel Detalhar(Expression<Func<DTO.Logon, bool>> where)
        {
            Logon retorno = null;
            try
            {
                retorno = this.repository.Detail(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
            }
            return this.mapper.Map<DTO.Logon, ViewModel.LogonViewModel>(retorno);
        }

        public void Excluir(Expression<Func<DTO.Logon, bool>> where)
        {
            try
            {
                this.repository.Delete(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Excluir] [{exception.Message}] ;", exception);
            }

        }

        public LogonViewModel Inserir(LogonViewModel model)
        {
            Logon retorno = null;
            try
            {
                model.Password = Security.ComputeSha256Hash(model.Password);
                var novo = new Logon();
                novo = this.mapper.Map< ViewModel.LogonViewModel, DTO.Logon>(model);
                novo.Ativo = (int)Status.Ativo;
                novo.DataInclusao = DateTime.Now;
                retorno = this.repository.Insert(novo);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Logon, ViewModel.LogonViewModel>(retorno);
        }

        public IEnumerable<LogonViewModel> Selecionar()
        {
            IEnumerable<Logon> retorno = Enumerable.Empty<Logon>();
            try
            {
                retorno = this.repository.Get();
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Logon>, IEnumerable<ViewModel.LogonViewModel>>(retorno);
        }

        public IEnumerable<LogonViewModel> Selecionar(Expression<Func<DTO.Logon, bool>> where)
        {
            IEnumerable<Logon> retorno = Enumerable.Empty<Logon>();
            try
            {
                retorno = this.repository.Get(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Logon>, IEnumerable<ViewModel.LogonViewModel>>(retorno);

        }
    }
}
