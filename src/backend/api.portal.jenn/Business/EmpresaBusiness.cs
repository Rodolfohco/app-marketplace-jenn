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

      

        public IEnumerable<ConsultaEmpresaViewModel> Selecionar()
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
            return this.mapper.Map<IEnumerable<DTO.Empresa>, IEnumerable<ViewModel.ConsultaEmpresaViewModel>>(retorno);
        }

        public IEnumerable<ConsultaEmpresaViewModel> Selecionar(Expression<Func<Empresa, bool>> where)
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
            return this.mapper.Map<IEnumerable<DTO.Empresa>, IEnumerable<ViewModel.ConsultaEmpresaViewModel>>(retorno);
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




        public IEnumerable<ConsultaProcedimentoEmpresaViewModel> SelecionarProcedimentoEmpresa()
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
            return this.mapper.Map<IEnumerable<DTO.ProcedimentoEmpresa>, IEnumerable<ViewModel.ConsultaProcedimentoEmpresaViewModel>>(retorno);
        }

        public IEnumerable<ConsultaProcedimentoEmpresaViewModel> SelecionarProcedimentoEmpresa(int EmpresaID)
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
            return this.mapper.Map<IEnumerable<DTO.ProcedimentoEmpresa>, IEnumerable<ViewModel.ConsultaProcedimentoEmpresaViewModel>>(retorno);
        }

        public ConsultaProcedimentoEmpresaViewModel InserirProcedimento(NovoProcedimentoEmpresaViewModel model)
        {
            ProcedimentoEmpresa retorno = null;
            try
            {
                var procedimentoEmpresa = this.mapper.Map<ViewModel.NovoProcedimentoEmpresaViewModel, DTO.ProcedimentoEmpresa>(model);
                procedimentoEmpresa.DataInclusao = DateTime.Now;


                retorno = this.repository.Insert(procedimentoEmpresa);

              
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [InserirProcedimento] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.ProcedimentoEmpresa, ViewModel.ConsultaProcedimentoEmpresaViewModel>(retorno);
        }

        public EmpresaViewModel Inserir(NovaEmpresaViewModel model)
        {
            Empresa retorno = null;
            try
            {
                var EmpresaNova = this.mapper.Map<ViewModel.NovaEmpresaViewModel, DTO.Empresa>(model);
                retorno = this.repository.Insert(EmpresaNova);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Empresa, ViewModel.EmpresaViewModel>(retorno);
        }

        public FilialViewModel InserirFilial(NovaFilialViewModel model)
        {
            Empresa retorno = null;
            try
            {
                var EmpresaNova = this.mapper.Map<ViewModel.NovaFilialViewModel, DTO.Empresa>(model);
                retorno = this.repository.Insert(EmpresaNova);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Empresa, ViewModel.FilialViewModel>(retorno);
        }

        public IEnumerable<ConsultaFilialViewModel> SelecionarFilial()
        {
            IEnumerable<Empresa> retorno = Enumerable.Empty<Empresa>();
            try
            {
                retorno = this.repository.GetFiliais(true);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Empresa>, IEnumerable<ViewModel.ConsultaFilialViewModel>>(retorno);
        }

        public  FilialViewModel DetalharFilial(int EmpresaID, int FilialID)
        {
       Empresa  retorno =null;
            try
            {
                retorno = this.repository.Detail(c=> c.EmpresaID== FilialID && c.MatrizID == EmpresaID , true);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Empresa, ViewModel.FilialViewModel>(retorno);
        }

        public void ExcluirFilial(Expression<Func<Empresa, bool>> where)
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

        public void AtualizarFilial(FilialViewModel model, int id)
        {
            try
            {
                this.repository.Update(
                   this.mapper.Map<ViewModel.FilialViewModel, DTO.Empresa>(model), id);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.Message}] ;", exception);
            }
        }

    
        public PagamentoProcedimentoEmpresaViewModel InserirPagamentoProcedimentoEmpresa(NovoPagamentoProcedimentoEmpresaViewModel model)
        {
            PagamentoProcedimentoEmpresa retorno = null;
            try
            {
                var novoPagamentoProcedimentoEmpresaViewModel = this.mapper.Map<ViewModel.NovoPagamentoProcedimentoEmpresaViewModel, DTO.PagamentoProcedimentoEmpresa>(model);
                retorno = this.repository.Insert(novoPagamentoProcedimentoEmpresaViewModel, model.ProcedimentoEmpresaID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.PagamentoProcedimentoEmpresa, ViewModel.PagamentoProcedimentoEmpresaViewModel>(retorno);
        }

        public PlanoProcedimentoEmpresaViewModel InserirPlanoProcedimentoEmpresa(PlanoProcedimentoEmpresaViewModel model)
        {
            PlanoProcedimentoEmpresa retorno = null;
            try
            {
                var PlanoNovo = this.mapper.Map<ViewModel.PlanoProcedimentoEmpresaViewModel, DTO.PlanoProcedimentoEmpresa>(model);
                retorno = this.repository.InsertPlanoProcedimentoEmpresa(PlanoNovo, model.ProcedimentoEmpresaID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.PlanoProcedimentoEmpresa, ViewModel.PlanoProcedimentoEmpresaViewModel>(retorno);
        }

        public FotoEmpresaViewModel Inserir(FotoEmpresaViewModel model, int EmpresaID)
        {
            FotoEmpresa retorno = null;
            try
            {
                var EmpresaNova = this.mapper.Map<ViewModel.FotoEmpresaViewModel, DTO.FotoEmpresa>(model);

              
                retorno = this.repository.Insert(EmpresaNova, EmpresaID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.FotoEmpresa, ViewModel.FotoEmpresaViewModel>(retorno);
        }

        public GrupoViewModel Inserir(GrupoViewModel model, int EmpresaID)
        {
            Grupo retorno = null;
            try
            {
                var EmpresaNova = this.mapper.Map<ViewModel.GrupoViewModel, DTO.Grupo>(model);
                retorno = this.repository.Insert(EmpresaNova, EmpresaID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.Message}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Grupo, ViewModel.GrupoViewModel>(retorno);
        }
    }
}