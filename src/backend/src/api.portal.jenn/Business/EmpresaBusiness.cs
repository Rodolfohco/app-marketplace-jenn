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
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.InnerException}] ;", exception);
            }
        }

        public IEnumerable<ConsultaAgendaViewModel> SelecionarAgendaProcedimentoEmpresa(int ProcedimentoID)
        {
            IEnumerable<Agenda> retorno = Enumerable.Empty<Agenda>();
            try
            {
                retorno = this.repository.GetNovaAgenda(ProcedimentoID, true);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.Agenda>, IEnumerable<ViewModel.ConsultaAgendaViewModel>>(retorno);
        }
        public ConsultaAgendaViewModel InserirAgendaProcedimentoEmpresa(NovoAgendaViewModel novaAgenda, int ProcedimentoEmpresaID)
        {
            Agenda retorno = null;
            try
            {
                var nova = this.mapper.Map<ViewModel.NovoAgendaViewModel, DTO.Agenda>(novaAgenda);
                retorno = this.repository.InsertNovaAgenda(nova, ProcedimentoEmpresaID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Agenda, ViewModel.ConsultaAgendaViewModel>(retorno);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.InnerException}] ;", exception);
            }
            return this.mapper.Map<DTO.Empresa, ViewModel.EmpresaViewModel>(retorno);
        }

        public EmpresaViewModel Detalhar(string nome)
        {
            Empresa retorno = null;
            try
            {
                retorno = this.repository.Detail(nome);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.InnerException}] ;", exception);
            }
            return this.mapper.Map<DTO.Empresa, ViewModel.EmpresaViewModel>(retorno);
        }




        public EmpresaViewModel DetalharMatriz( string nome)
        {
            Empresa retorno = null;
            try
            {
                retorno = this.repository.Detail(empresa => empresa.Nome.Trim().ToLower().Equals(nome.Trim().ToLower()));
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Excluir] [{exception.InnerException}] ;", exception);
                throw;
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
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Detalhar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [InserirProcedimento] [{exception.InnerException}] ;", exception);
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

                if (model.GrupoId > 0)
                    EmpresaNova.Grupo = new Grupo() { GrupoID = model.GrupoId };

                if (!string.IsNullOrEmpty(model.NumeroCidade))
                    EmpresaNova.Cidade = new Cidade() { num_cidade = model.NumeroCidade };

                retorno = this.repository.Insert(EmpresaNova);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Empresa, ViewModel.EmpresaViewModel>(retorno);
        }

        public FilialViewModel InserirFilial(NovaFilialViewModel model)
        {
            Empresa retorno = null;
            var EmpresaNova = new DTO.Empresa();

            try
            {

                var detalhe = this.Detalhar(model.Matriz);

                    if(detalhe !=null)
                        EmpresaNova.MatrizID = detalhe.EmpresaID;

                    EmpresaNova.Ativo = model.Ativo;
                    EmpresaNova.bairro = model.bairro;
                    EmpresaNova.cep = model.cep;
                    EmpresaNova.Cert_Empresa = model.Cert_Empresa;
                    EmpresaNova.cnpj = model.cnpj;
                    EmpresaNova.CodigoCnes = model.CodigoCnes;
                    EmpresaNova.Email = model.Email;
                    EmpresaNova.Id_classe = model.Id_classe;
                    EmpresaNova.ImgemFrontEmpresa = model.ImgemFrontEmpresa;
                    EmpresaNova.Logradouro = model.Logradouro;
                    EmpresaNova.Nome = model.Nome;
                    EmpresaNova.numero = model.numero;
                    EmpresaNova.bairro = model.bairro;
                    EmpresaNova.Telefone1 = model.Telefone1;
                    EmpresaNova.Telefone2 = model.Telefone2;
                    EmpresaNova.TipoEmpresa = model.TipoEmpresa;
                    EmpresaNova.url_loja = model.url_loja;
                    EmpresaNova.maps = model.maps;
                    EmpresaNova.Responsavel = model.Responsavel;


                if (model.GrupoId > 0)
                    EmpresaNova.Grupo = new Grupo() { GrupoID = model.GrupoId };

                if (!string.IsNullOrEmpty(model.NumeroCidade))
                    EmpresaNova.Cidade = new Cidade() { num_cidade = model.NumeroCidade };



                retorno = this.repository.Insert(EmpresaNova);
                
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Selecionar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Atualizar] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
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
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.Grupo, ViewModel.GrupoViewModel>(retorno);
        }

        public ConsultaNovaConfirmacaoAgendaViewModel InserirConfirmacaoAgenda(NovaConfirmacaoAgendaViewModel novaAgenda)
        {
            ConfirmacaoAgenda retorno = null;
            try
            {
                retorno = this.repository.InsertConfirmacaoAgenda(novaAgenda);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Inserir] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.ConfirmacaoAgenda, ViewModel.ConsultaNovaConfirmacaoAgendaViewModel>(retorno);
        }

        public ConsultaProcedimentoEmpresa2ViewModel DetalharProcedimentoEmpresa(int ProcedimentoEmpresaID)
        {
            ProcedimentoEmpresa retorno = null;
            try
            {
                retorno = this.repository.DetailProcedimentoEmpresa(ProcedimentoEmpresaID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.ProcedimentoEmpresa, ViewModel.ConsultaProcedimentoEmpresa2ViewModel>(retorno);
        }

        public ConsultaProcedimentoSinonimoViewModel InsertProcedimentoSinonimo(NovoProcedimentoSinonimoViewModel model)
        {
            ProcedimentoSinonimo retorno = null;
            var param = this.mapper.Map<ViewModel.NovoProcedimentoSinonimoViewModel, DTO.ProcedimentoSinonimo> (model);
            try
            {
                retorno = this.repository.InsertProcedimentoSinonimo(param, model.ProcedimentoID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.ProcedimentoSinonimo, ViewModel.ConsultaProcedimentoSinonimoViewModel>(retorno);
        }

        public IEnumerable<ConsultaProcedimentoSinonimoViewModel> GetProcedimentoSinonimoID(int ProcedimentoID)
        {
            IEnumerable< ProcedimentoSinonimo> retorno = null;
          
            try
            {
                retorno = this.repository.GetProcedimentoSinonimoId(ProcedimentoID);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.ProcedimentoSinonimo>, IEnumerable<ViewModel.ConsultaProcedimentoSinonimoViewModel>>(retorno);
        }

        public IEnumerable<ConsultaProcedimentoSinonimoViewModel> GetProcedimentoSinonimo()
        {
            IEnumerable<ProcedimentoSinonimo> retorno = null;

            try
            {
                retorno = this.repository.GetProcedimentoSinonimo( );
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.ProcedimentoSinonimo>, IEnumerable<ViewModel.ConsultaProcedimentoSinonimoViewModel>>(retorno);
        }

        public IEnumerable<ConsultaProcedimentoSinonimoViewModel> GetProcedimentoSinonimoPorNome(string PorNome)
        {
            IEnumerable<ProcedimentoSinonimo> retorno = null;

            try
            {
                retorno = this.repository.GetProcedimentoSinonimoPorNome(PorNome);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<IEnumerable<DTO.ProcedimentoSinonimo>, IEnumerable<ViewModel.ConsultaProcedimentoSinonimoViewModel>>(retorno);
        }

        public PlanoProcedimentoEmpresaViewModel VincularPlanoProcedimentoEmpresa(VincularPlanoProcedimentoEmpresaViewModel model)
        {
            PlanoProcedimentoEmpresa retorno = null;
        
            try
            {
                retorno = this.repository.VincularPlanoProcedimentoEmpresa(model.PlanoID, model.ProcedimentoEmpresaID, null);
            }
            catch (Exception exception)
            {
                this._logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return this.mapper.Map<DTO.PlanoProcedimentoEmpresa, ViewModel.PlanoProcedimentoEmpresaViewModel>(retorno);
        }
    }
}