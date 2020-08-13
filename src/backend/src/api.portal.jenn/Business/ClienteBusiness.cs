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
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly ICidadeBusiness cidadeBusiness;
        private readonly IClienteRepository repository;
        private readonly ILogger<ClienteBusiness> _logger;
        private readonly IMapper mapper;

        public ClienteBusiness(
            ILogger<ClienteBusiness> logger, 
            IClienteRepository _repository, 
            IMapper _mapper, 
            ICidadeBusiness _cidadeBusiness)
        {
            this.mapper = _mapper;
            this.repository = _repository;
            this._logger = logger;
            this.cidadeBusiness = _cidadeBusiness;
        }

        public void DeletarCliente(Expression<Func<Cliente, bool>> where)
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

        public void DeletarContato(Expression<Func<Contato, bool>> where)
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

        public ClienteViewModel DetalharCliente(Expression<Func<Cliente, bool>> where, bool lazzLoader = false)
        {
            Cliente cliente = null;
            try
            {
                cliente = this.repository.Detail(where, lazzLoader);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<Cliente, ClienteViewModel>(cliente); ;
        }

        public ContatoViewModel DetalheContato(Expression<Func<Contato, bool>> where, bool lazzLoader = false)
        {
            Contato contato = null;
            try
            {
                contato = this.repository.Detail(where, lazzLoader);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<Contato, ContatoViewModel>(contato); ;
        }
    

        public ContatoViewModel InseriContato(NovoContatoViewModel model)
        {
            Contato retorno = null;
            try
            {
                var NovaCidade = this.mapper.Map<ViewModel.NovoContatoViewModel, DTO.Contato>(model);
                retorno = this.repository.Insert(NovaCidade);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Contato, ViewModel.ContatoViewModel>(retorno);
        }

        public ClienteViewModel InserirCliente(ClienteViewModel model)
        {
            Cliente retorno = null;
            try
            {
                var NovaCidade = this.mapper.Map<ViewModel.ClienteViewModel, DTO.Cliente>(model);
                retorno = this.repository.Insert(NovaCidade);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Cliente, ViewModel.ClienteViewModel>(retorno);
        }

        public IEnumerable<ClienteViewModel> SelecionarCliente(bool lazzLoader = false)
        {
            IEnumerable<Cliente> retorno = Enumerable.Empty<Cliente>();
            try
            {
                retorno = this.repository.Get(lazzLoader);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Cliente>, IEnumerable<ViewModel.ClienteViewModel>>(retorno);
        }

        public IEnumerable<ClienteViewModel> SelecionarCliente(Expression<Func<Cliente, bool>> where, bool lazzLoader = false)
        {
            IEnumerable<Cliente> retorno = Enumerable.Empty<Cliente>();
            try
            {
                retorno = this.repository.Get(where, lazzLoader);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Cliente>, IEnumerable<ViewModel.ClienteViewModel>>(retorno);
        }

        public IEnumerable<ContatoViewModel> SelecionarContato(bool lazzLoader = false)
        {
            IEnumerable<Contato> retorno = Enumerable.Empty<Contato>();
            try
            {
                retorno = this.repository.GetContato( lazzLoader);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Contato>, IEnumerable<ViewModel.ContatoViewModel>>(retorno);
        }

        public IEnumerable<ContatoViewModel> SelecionarContato(Expression<Func<Contato, bool>> where, bool lazzLoader = false)
        {
            IEnumerable<Contato> retorno = Enumerable.Empty<Contato>();
            try
            {
                retorno = this.repository.Get(where, lazzLoader);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Contato>, IEnumerable<ViewModel.ContatoViewModel>>(retorno);
        }
    }
}
