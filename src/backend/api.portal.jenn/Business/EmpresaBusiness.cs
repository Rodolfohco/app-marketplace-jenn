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
    public class EmpresaBusiness : IEmpresaBusiness
    {
        private readonly IEmpresaRepository repository;
        private readonly ILogger<EmpresaBusiness> _logger;
        private readonly IMapper mapper;

        public EmpresaBusiness(
            ILogger<EmpresaBusiness> logger,
            IEmpresaRepository _repository,
             IMapper _mapper)
        {
            this.mapper = _mapper;
            this.repository = _repository;
            this._logger = logger;
        }

        public void Atualizar(EmpresaViewModel model, int id)
        {
            try
            {
                this.repository.Update(
                   this.mapper.Map<ViewModel.EmpresaViewModel, DTO.Empresa>(model), id);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.Message}] ;", exception);
            }
        }

        public EmpresaViewModel Detalhar(Expression<Func<Empresa, bool>> where)
        {
            Empresa retorno = null;
            try
            {
                retorno = this.repository.Detail(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
            }
            return this.mapper.Map<DTO.Empresa, ViewModel.EmpresaViewModel>(retorno);
        }

        public void Excluir(Expression<Func<Empresa, bool>> where)
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

        public EmpresaViewModel Inserir(EmpresaViewModel model)
        {
            Empresa retorno = null;
            try
            {
                if (model.MatrizID.HasValue && model.MatrizID.Value <= 0)
                    model.MatrizID = null;
                model.Matrizes = null;


                var EmpresaNova = this.mapper.Map<ViewModel.EmpresaViewModel, DTO.Empresa>(model);
                retorno = this.repository.Insert(EmpresaNova);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Empresa, ViewModel.EmpresaViewModel>(retorno);
        }

        public IEnumerable<EmpresaViewModel> Selecionar()
        {
            IEnumerable<Empresa> retorno = Enumerable.Empty<Empresa>();
            try
            {
                retorno = this.repository.Get();
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Empresa>, IEnumerable<ViewModel.EmpresaViewModel>>(retorno);
        }

        public IEnumerable<EmpresaViewModel> Selecionar(Expression<Func<Empresa, bool>> where)
        {
            IEnumerable<Empresa> retorno = Enumerable.Empty<Empresa>();
            try
            {
                retorno = this.repository.Get(where);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Empresa>, IEnumerable<ViewModel.EmpresaViewModel>>(retorno);
        }

        public IEnumerable<EmpresaViewModel> Selecionar(bool lazzyLoader = false)
        {
            IEnumerable<Empresa> retorno = Enumerable.Empty<Empresa>();
            try
            {
                retorno = this.repository.Get(lazzyLoader);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Empresa>, IEnumerable<ViewModel.EmpresaViewModel>>(retorno);
        }

        public IEnumerable<EmpresaViewModel> Selecionar(Expression<Func<Empresa, bool>> where, bool lazzyLoader = false)
        {
            IEnumerable<Empresa> retorno = Enumerable.Empty<Empresa>();
            try
            {
                retorno = this.repository.Get(where, lazzyLoader);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Empresa>, IEnumerable<ViewModel.EmpresaViewModel>>(retorno);
        }

        public EmpresaViewModel Detalhar(Expression<Func<Empresa, bool>> where, bool lazzyLoader = false)
        {
            Empresa retorno = null;
            try
            {
                retorno = this.repository.Detail(where, lazzyLoader);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.Message}] ;", exception);
            }
            return this.mapper.Map<DTO.Empresa, ViewModel.EmpresaViewModel>(retorno);
        }




        public IEnumerable<ProcedimentoEmpresaViewModel> SelecionarProcedimentoEmpresa()
        {
            IEnumerable<ProcedimentoEmpresa> retorno = Enumerable.Empty<ProcedimentoEmpresa>();
            try
            {
                retorno = this.repository.GetProcedimentoEmpresa();
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.ProcedimentoEmpresa>, IEnumerable<ViewModel.ProcedimentoEmpresaViewModel>>(retorno);
        }

        public IEnumerable<ProcedimentoEmpresaViewModel> SelecionarProcedimentoEmpresa(int EmpresaID)
        {
            IEnumerable<ProcedimentoEmpresa> retorno = Enumerable.Empty<ProcedimentoEmpresa>();
            try
            {
                retorno = this.repository.GetProcedimentoEmpresa(EmpresaID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.ProcedimentoEmpresa>, IEnumerable<ViewModel.ProcedimentoEmpresaViewModel>>(retorno);
        }

        public ProcedimentoEmpresaViewModel InserirProcedimento(ProcedimentoEmpresaViewModel model, int EmpresaID, int ProcedimentoID)
        {
            ProcedimentoEmpresa retorno = null;
            try
            {
                var procedimentoEmpresa = this.mapper.Map<ViewModel.ProcedimentoEmpresaViewModel, DTO.ProcedimentoEmpresa>(model);
          
                procedimentoEmpresa.DataInclusao = DateTime.Now;
              

                retorno = this.repository.Insert(procedimentoEmpresa, EmpresaID, ProcedimentoID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [InserirProcedimento] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.ProcedimentoEmpresa, ViewModel.ProcedimentoEmpresaViewModel>(retorno);
        }
    }
}