using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.factory;
using api.portal.jenn.ViewModel;
using database.portal.jenn.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml;

namespace api.portal.jenn.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly EmpresaContextFactory contexto;
        private readonly ILogger<EmpresaRepository> logger;
        private readonly IConfiguration configuration;
        private readonly IProcedimentoRepository procedimento;


        public EmpresaRepository(
          IProcedimentoRepository _procedimento,
          IConfiguration _configuration,
          ILogger<EmpresaRepository> _logger,
          EmpresaContextFactory _context)
            {
            this.configuration = _configuration;
            this.logger = _logger;
            this.procedimento = _procedimento;
            this.contexto = _context;
            }

        public void Delete(Expression<Func<Empresa, bool>> where)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    var item = Detail(where);
                    if (item != null)
                    {
                        ctx.Empresas.Remove(item);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Delete] [{exception.InnerException}] ;", exception);
                throw;
            }
        }

        public Empresa Detail(Expression<Func<Empresa, bool>> where, bool lazzLoader = false)
        {
            Empresa retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                    {
                        retorno = ctx.Empresas
                            .Include(c => c.ProcedimentoEmpresas)
                           .ThenInclude(c => c.Procedimento)
                           .ThenInclude(c => c.TipoProcedimento)
                           .ThenInclude(c => c.Categoria)
                           .Include(c => c.Cidade)
                           .ThenInclude(c => c.Regiao)
                           .Include(c => c.Cidade)
                           .ThenInclude(c => c.Uf).Where(where).SingleOrDefault();
                    }
                    else
                        retorno = ctx.Empresas.Where(where).SingleOrDefault();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }



        public IEnumerable<Empresa> Get(bool lazzLoader = false)
        {
            List<Empresa> retorno = new List<Empresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    ctx.Empresas
                                .Include(c => c.Fotos)
                                .Include(c => c.Grupo)
                                .Include(c => c.ProcedimentoEmpresas)
                                .ThenInclude(c => c.PagamentoProcedimentoEmpresas)
                                .ThenInclude(c => c.Pagamento)
                                .Include(c => c.ProcedimentoEmpresas)
                                .ThenInclude(c => c.PlanoProcedimentoEmpresas)
                                .ThenInclude(c => c.Plano)
                                .ThenInclude(c => c.Convenio)
                                .Include(c => c.ProcedimentoEmpresas)
                                .ThenInclude(c => c.Procedimento)
                                .ThenInclude(c => c.TipoProcedimento)
                                .ThenInclude(c => c.Categoria)
                                .Include(c => c.ProcedimentoEmpresas)
                                .ThenInclude(c => c.Agendas)
                                .Include(c => c.Cidade)
                                .ThenInclude(c => c.Regiao)
                                .Include(c => c.Cidade)
                                .ThenInclude(c => c.Uf)
                                .Where(c => c.Ativo > 0)
                            .AsParallel().ForAll(
                        item =>
                        {
                            retorno.Add(item);
                        });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

 
        public IEnumerable<Empresa> Get(Expression<Func<Empresa, bool>> where, bool lazzLoader = false)
        {
            List<Empresa> retorno = new List<Empresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                               ctx.Empresas.Where(where).AsParallel().ForAll(item => { retorno.Add(item); });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Empresa> GetFiliais(bool lazzLoader = false)
        {
            List<Empresa> retorno = new List<Empresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    retorno = (from p in ctx.Empresas
                                  join e in ctx.Empresas
                                  on p.EmpresaID equals e.MatrizID
                                  where p.Ativo > 0
                                  select e)
                                  .Include(c => c.Cidade)
                                  .ThenInclude(c=> c.Regiao)
                                  .Include(c=> c.Cidade)
                                  .ThenInclude(c=> c.Regiao)
                                  .Include(c=> c.ProcedimentoEmpresas)
                                  .ThenInclude(c=> c.Procedimento)
                                  .ThenInclude(c=> c.TipoProcedimento)
                                  .Include(c => c.ProcedimentoEmpresas)
                                  .ThenInclude(c=> c.PagamentoProcedimentoEmpresas)
                                  .ThenInclude(c => c.Pagamento)
                                  .ToList();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<Agenda> GetNovaAgenda(int ProcedimentoEmpresaID, bool lazzLoader = false)
        {
            List<Agenda> retorno = new List<Agenda>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    ctx.ProcedimentoEmpresa.Include(c => c.Agendas)
                        .Where(c => c.ProcedimentoEmpresaID==ProcedimentoEmpresaID)
                        .SelectMany(c=> c.Agendas).ToList()
                        .AsParallel().ForAll(
                        item =>
                        {
                            retorno.Add(item);
                        });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<ProcedimentoEmpresa> GetProcedimentoEmpresa(int EmpresaID)
        {
            List<ProcedimentoEmpresa> retorno = new List<ProcedimentoEmpresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    ctx.Empresas.Where(c => c.EmpresaID == EmpresaID).Include(c => c.ProcedimentoEmpresas)
                        .Select(c => c.ProcedimentoEmpresas).AsParallel().ForAll(
                        item =>
                        {
                            retorno.AddRange(item.ToArray());
                        });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<ProcedimentoEmpresa> GetProcedimentoEmpresa()
        {
            List<ProcedimentoEmpresa> retorno = new List<ProcedimentoEmpresa>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    ctx.ProcedimentoEmpresa
                        .Include(x=> x.Agendas)
                        .Include(x => x.Procedimento)
                        .ThenInclude(p => p.TipoProcedimento)
                        .Include(c => c.Empresa)
                        .ThenInclude(c => c.Matriz)
                        .ThenInclude(x => x.Cidade)
                        .ToList().ForEach(
                        item =>
                        {
                            retorno.Add(item);
                        });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }


        public Empresa Insert(Empresa model)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                   ctx.Add(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.InnerException}] ;", exception);
                throw;
            }
            return model;
        }

        public ProcedimentoEmpresa Insert(ProcedimentoEmpresa model)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    ctx.ProcedimentoEmpresa.Add(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Update] [{exception.InnerException}] ;", exception);
                throw;
            }
            return model;
        }
        public PagamentoProcedimentoEmpresa Insert(PagamentoProcedimentoEmpresa model, int ProcedimentoID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var procedimento = ctx.ProcedimentoEmpresa.Where(c => c.ProcedimentoEmpresaID ==  ProcedimentoID).Include(c => c.PagamentoProcedimentoEmpresas).SingleOrDefault();
                    procedimento.PagamentoProcedimentoEmpresas.Add(model);
                    ctx.Entry(procedimento).State = EntityState.Modified;
              

                    ctx.ProcedimentoEmpresa.Update(procedimento);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.InnerException}] ;", exception);
                throw;
            }
            return model;
        }
        public PlanoProcedimentoEmpresa Insert(PlanoProcedimentoEmpresa model)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    ctx.PlanoProcedimentoEmpresas.Add(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.InnerException}] ;", exception);
                throw;
            }
            return model;
        }
        public FotoEmpresa Insert(FotoEmpresa model, int EmpresaID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var empresa = ctx.Empresas.Where(c => c.EmpresaID == EmpresaID).Include(c => c.Fotos).SingleOrDefault();
                    empresa.Fotos.Add(model);
                    ctx.Entry(empresa).State = EntityState.Modified;

                    ctx.Empresas.Update(empresa);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.InnerException}] ;", exception);
                throw;
            }
            return model;
        }
        public Grupo Insert(Grupo model, int EmpresaID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var empresa = ctx.Empresas.Where(c => c.EmpresaID == EmpresaID).Include(c => c.Grupo).SingleOrDefault();
                    empresa.Grupo = model;
                    ctx.Entry(empresa).State = EntityState.Modified;

                    ctx.Empresas.Update(empresa);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.InnerException}] ;", exception);
                throw;
            }
            return model;
        }

        public ConfirmacaoAgenda InsertConfirmacaoAgenda(ConfirmacaoAgendaViewModel model)
        {
            ConfirmacaoAgenda confirmacaoAgenda = new ConfirmacaoAgenda();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    //Paciente paciente = model.Paciente;
                    //Cliente cliente = ctx.Clientes.Find(model.ClienteID);



                   
                    
                
                    ProcedimentoEmpresa procedimento = ctx.ProcedimentoEmpresa.Find(model.ProcedimentoEmpresaID);
                    Agenda agenda = ctx.Agenda.Find(model.PlanoID);
                    Cliente cliente = ctx.Clientes.Find(model.ClienteID);
                    Plano plano = ctx.Planos.Find(model.PlanoID);

                    Paciente paciente = new Paciente()
                    {
                        bairro = model.Paciente.bairro,
                        Celular = model.Paciente.Celular,
                        Nome = model.Paciente.Nome,
                        Telefone = model.Paciente.Telefone,
                        Cep = model.Paciente.Cep,
                        cpf_paciente = model.Paciente.cpf_paciente,
                        DtaNascimento = model.Paciente.DtaNascimento,
                        Logradouro = model.Paciente.Logradouro,
                        numero = model.Paciente.numero,
                        Referencia = model.Paciente.Referencia,
                        Sexo = model.Paciente.Sexo,
                        sobrenome = model.Paciente.sobrenome

                    };
                    ctx.Entry(paciente).State = EntityState.Added;


                    ctx.Pacientes.Add(paciente);
                    ctx.SaveChanges();




                    confirmacaoAgenda.Paciente = paciente;
                    confirmacaoAgenda.Agenda  = agenda;
                    confirmacaoAgenda.Cliente = cliente;
                    confirmacaoAgenda.Plano = plano;
                    confirmacaoAgenda.ProcedimentoEmpresa = procedimento;


                    confirmacaoAgenda.Altura = model.Altura;
                    confirmacaoAgenda.AlergiaReacoes = model.AlergiaReacoes;
                    confirmacaoAgenda.Peso = model.Peso;
                    confirmacaoAgenda.PacienteTitular = model.PacienteTitular;
                    confirmacaoAgenda.contraste = model.contraste;
                    confirmacaoAgenda.CarteirinhaConvenio = model.CarteirinhaConvenio;


                    ctx.Entry(confirmacaoAgenda).State = EntityState.Added;


                    ctx.ConfirmacaoAgenda.Attach(confirmacaoAgenda);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.InnerException}] ;", exception);
                throw;
            }
            return confirmacaoAgenda;
        }


        public Agenda InsertNovaAgenda(Agenda model, int ProcedimentoEmpresaID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var procedimento = ctx.ProcedimentoEmpresa.Find(ProcedimentoEmpresaID);
                    model.ProcedimentoEmpresa = procedimento;
                    ctx.Agenda.Attach(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.InnerException}] ;", exception);
                throw;
            }
            return model;
        }
        public PlanoProcedimentoEmpresa InsertPlanoProcedimentoEmpresa(PlanoProcedimentoEmpresa model, int ProcedimentoID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var procedimentoEmpresa = ctx.ProcedimentoEmpresa.Include(x=> x.PlanoProcedimentoEmpresas).Where(x => x.ProcedimentoEmpresaID == ProcedimentoID).FirstOrDefault();
                    procedimentoEmpresa.PlanoProcedimentoEmpresas.Add(model);
                    ctx.Entry(procedimentoEmpresa).State = EntityState.Modified;
                    ctx.ProcedimentoEmpresa.Update(procedimentoEmpresa);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.InnerException}] ;", exception);
                throw;
            }
            return model;
        }
        public void Update(Empresa model, int id)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var item = Detail(c => c.EmpresaID == id);
                    if (item != null)
                    {
                        model.EmpresaID = id;

                        ctx.Update(model);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Update] [{exception.InnerException}] ;", exception);
                throw;
            }
        }
    }
}
