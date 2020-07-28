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

     
        public void Atualizar(NovoLogonViewModel model, int id)
        {
            try
            {
                model.Password = Security.ComputeSha256Hash(model.Password);

                this.repository.Update(
                   this.mapper.Map<ViewModel.NovoLogonViewModel, DTO.Logon>(model), id);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.Message}] ;", exception);
            }
        }

        //public ConsultaLogonViewModel Detalhar(string usuario, string password)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ConsultaLogonViewModel> DetalharAsync(string usuario, string password)
        {
            Logon retorno = null;
            try
            {
                retorno = await this.repository.DetailAsync(c => c.Email == usuario && c.Password == password);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
            }
            return this.mapper.Map<DTO.Logon, ViewModel.ConsultaLogonViewModel>(retorno);
        }

        public ConsultaLogonViewModel Inserir(NovoLogonViewModel model)
        {
            Logon retorno = null;
            try
            {
                model.Password = Security.ComputeSha256Hash(model.Password);
                var novo = new Logon();
                novo = this.mapper.Map<ViewModel.NovoLogonViewModel, DTO.Logon>(model);
               

                novo.Ativo = (int)Status.Ativo;
                novo.DataInclusao = DateTime.Now;
               
                retorno = this.repository.Insert(novo);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Logon, ViewModel.ConsultaLogonViewModel>(retorno);
        }

   
    }
}
