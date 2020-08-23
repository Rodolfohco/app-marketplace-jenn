using api.portal.jenn.Contract;
using api.portal.jenn.DTO;
using api.portal.jenn.factory;
using api.portal.jenn.ViewModel;
using database.portal.jenn.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public Empresa Detail(string nome, bool lazzLoader = false)
        {
            Empresa retorno = null;
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    if (lazzLoader)
                    {
                        retorno = ctx.Empresas.Where(c => c.Nome == nome)
                            .Include(c => c.ProcedimentoEmpresas)
                           .ThenInclude(c => c.Procedimento)
                           .ThenInclude(c => c.TipoProcedimento)
                           .ThenInclude(c => c.Categoria)
                           .Include(c => c.Cidade)
                           .ThenInclude(c => c.Regiao)
                           .Include(c => c.Cidade)
                           .ThenInclude(c => c.Uf).FirstOrDefault();
                    }
                    else
                    {
                        retorno = (from item in ctx.Empresas.ToList()
                                   where item.Nome.Trim().ToUpper() == nome.Trim().ToUpper()
                                   select item).FirstOrDefault();
                    }

                }
            }


            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Detail] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
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

                    (from item in ctx.Empresas.Where(a => a.Ativo == Status.Ativo)
                                 .Include(c => c.Fotos)
                                 .Include(c => c.Grupo)
                                 .Include(c => c.ProcedimentoEmpresas )
                                 .ThenInclude(c => c.PagamentoProcedimentoEmpresas)
                                 .ThenInclude(c => c.Pagamento)
                                 .Include(c => c.ProcedimentoEmpresas )
                                 .ThenInclude(c => c.PlanoProcedimentoEmpresas)
                                 .ThenInclude(c => c.Plano)
                                 .ThenInclude(c => c.Convenio)
                                 .Include(c => c.ProcedimentoEmpresas )
                                 .ThenInclude(c => c.Procedimento)
                                 .ThenInclude(c => c.TipoProcedimento)
                                 .ThenInclude(c => c.Categoria)
                                 .Include(c => c.ProcedimentoEmpresas)
                                 .ThenInclude(c => c.Agendas)
                                 .Include(c => c.Cidade)
                                 .ThenInclude(c => c.Regiao)
                                 .Include(c => c.Cidade)
                                 .ThenInclude(c => c.Uf)
                   
                     select item).AsParallel().ForAll(
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
                                  .ThenInclude(c => c.Regiao)
                                  .Include(c => c.Cidade)
                                  .ThenInclude(c => c.Regiao)
                                  .Include(c => c.ProcedimentoEmpresas)
                                  .ThenInclude(c => c.Procedimento)
                                  .ThenInclude(c => c.TipoProcedimento)
                                  .Include(c => c.ProcedimentoEmpresas)
                                  .ThenInclude(c => c.PagamentoProcedimentoEmpresas)
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
                        .Where(c => c.ProcedimentoEmpresaID == ProcedimentoEmpresaID)
                        .SelectMany(c => c.Agendas).ToList()
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
                        .Include(x => x.Agendas)
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
        public Empresa InsertFilial(Empresa model)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {
                    var matriz = ctx.Empresas.Include(x => x.Matriz).Select(x => x.Matriz).Where(x => x.Nome.Trim().ToUpper() == model.Matriz.Nome).FirstOrDefault();
                    model.Matriz = matriz;
                    ctx.Empresas.Add(model);



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

        public Empresa InsertMatriz(Empresa model, string NomeMatriz)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    var Matriz = ctx.Empresas.Where(x => x.Nome == NomeMatriz).FirstOrDefault();
                    model.Matriz = Matriz;

                    ctx.Empresas.Add(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
                throw;
            }
            return model;
        }

        public Empresa Insert(Empresa model)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {


                    if (model.MatrizID.HasValue)
                    {
                        var Matriz = ctx.Empresas.Include(X => X.Matriz).Select(x => x.Matriz).Where(c => c.MatrizID == model.MatrizID).FirstOrDefault();
                        model.Matriz = Matriz;
                    }

                    if (model.Grupo != null && model.Grupo.GrupoID > 0)
                    {
                        var grupo = ctx.Grupo.Find(model.Grupo.GrupoID);
                        model.Grupo = grupo;
                    }

                    if (model.Cidade != null && !string.IsNullOrEmpty(model.Cidade.num_cidade))
                    {
                        var Cidade = ctx.Cidades.Where(x => x.Uf.num_uf == model.Cidade.num_cidade.Substring(0,2) && x.num_cidade == model.Cidade.num_cidade.Substring(2)).FirstOrDefault();

                        if (Cidade != null)
                            model.Cidade = Cidade;
                    }

                    var empresaPesquisa = ctx.Empresas.Where(x => x.Nome == model.Nome && x.cnpj == model.cnpj).FirstOrDefault();
                    if (empresaPesquisa == null)
                    {
                        ctx.Empresas.Add(model);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
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
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
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
                    var procedimento = ctx.ProcedimentoEmpresa.Where(c => c.ProcedimentoEmpresaID == ProcedimentoID).Include(c => c.PagamentoProcedimentoEmpresas).SingleOrDefault();
                    procedimento.PagamentoProcedimentoEmpresas.Add(model);
                    ctx.Entry(procedimento).State = EntityState.Modified;


                    ctx.ProcedimentoEmpresa.Update(procedimento);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
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
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
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
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
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
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
                throw;
            }
            return model;
        }

        public ConfirmacaoAgenda InsertConfirmacaoAgenda(NovaConfirmacaoAgendaViewModel model)
        {
            ConfirmacaoAgenda confirmacaoAgenda = new ConfirmacaoAgenda();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {


                    ProcedimentoEmpresa procedimento = ctx.ProcedimentoEmpresa.Find(model.ProcedimentoEmpresaID);
                    Agenda agenda = ctx.Agenda.Find(model.PlanoID);

                    Plano plano = ctx.Planos.Find(model.PlanoID);

                    Cliente cliente = ctx.Clientes.Where(x => x.cpf_cliente == model.Cliente.cpf_cliente).FirstOrDefault();
                    Paciente paciente = ctx.Pacientes.Where(x => x.cpf_paciente == model.Paciente.cpf_paciente).FirstOrDefault();



                    if (cliente == null)
                    {
                        cliente = new Cliente()
                        {
                            bairro = model.Cliente.bairro,
                            Celular = model.Cliente.Celular,
                            Nome = model.Cliente.Nome,
                            Telefone = model.Cliente.Telefone,
                            Cep = model.Cliente.Cep,
                            cpf_cliente = model.Cliente.cpf_cliente,
                            DtaNascimento = model.Cliente.DtaNascimento,
                            Logradouro = model.Cliente.Logradouro,
                            numero = model.Cliente.numero,
                            Referencia = model.Cliente.Referencia,
                            Sexo = model.Cliente.Sexo,
                            sobrenome = model.Cliente.sobrenome
                        };
                        ctx.Entry(cliente).State = EntityState.Added;
                        ctx.Clientes.Add(cliente);
                        ctx.SaveChanges();
                    }

                    if (!model.PacienteTitular)
                    {
                        if (paciente == null)
                        {
                            paciente = new Paciente()
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
                        }
                    }
                    else
                    {
                        paciente = ctx.Pacientes.Where(x => x.cpf_paciente == model.Cliente.cpf_cliente).FirstOrDefault();

                        if (paciente == null)
                        {
                            paciente = new Paciente()
                            {
                                bairro = model.Cliente.bairro,
                                Celular = model.Cliente.Celular,
                                Nome = model.Cliente.Nome,
                                Telefone = model.Cliente.Telefone,
                                Cep = model.Cliente.Cep,
                                cpf_paciente = model.Cliente.cpf_cliente,
                                DtaNascimento = model.Cliente.DtaNascimento,
                                Logradouro = model.Cliente.Logradouro,
                                numero = model.Cliente.numero,
                                Referencia = model.Cliente.Referencia,
                                Sexo = model.Cliente.Sexo,
                                sobrenome = model.Cliente.sobrenome

                            };
                            ctx.Entry(paciente).State = EntityState.Added;
                            ctx.Pacientes.Add(paciente);
                            ctx.SaveChanges();
                        }


                    }



                    confirmacaoAgenda.Paciente = paciente;
                    confirmacaoAgenda.Agenda = agenda;
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


                    ctx.ConfirmacaoAgenda.Add(confirmacaoAgenda);
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
                    var procedimentoEmpresa = ctx.ProcedimentoEmpresa.Include(x => x.PlanoProcedimentoEmpresas).Where(x => x.ProcedimentoEmpresaID == ProcedimentoID).FirstOrDefault();

                    var convenio = ctx.Convenios.Where(x => x.Nome == model.Plano.Convenio.Nome).FirstOrDefault();

                    if(convenio!= null)
                    {
                      var plano =   convenio.Planos.Where(x => x.Nome == model.Plano.Nome).FirstOrDefault();

                        if (plano != null)
                            model.Plano = plano;

                    }

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
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
                throw;
            }
        }

        public ProcedimentoEmpresa DetailProcedimentoEmpresa(int ProcedimentoEmpresaID)
        {
            ProcedimentoEmpresa retorno = new ProcedimentoEmpresa();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))

                    retorno = ctx.ProcedimentoEmpresa.Include(c => c.Empresa).Include(C => C.Procedimento).ThenInclude(c => c.TipoProcedimento).Where(c => c.ProcedimentoID == ProcedimentoEmpresaID).FirstOrDefault();
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Get] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }

        public ProcedimentoSinonimo InsertProcedimentoSinonimo(ProcedimentoSinonimo model, int ProcedimentoID)
        {
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    var Procedimento = ctx.Procedimento.Include(x => x.ProcedimentoSinonimos).Where(x => x.ProcedimentoID == ProcedimentoID).FirstOrDefault();

                    Procedimento.ProcedimentoSinonimos.Add(model);

                    ctx.Entry(Procedimento).State = EntityState.Modified;


                    ctx.Procedimento.Update(Procedimento);
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
                throw;
            }
            return model;
        }

        public IEnumerable<ProcedimentoSinonimo> GetProcedimentoSinonimoId(int ProcedimentoID)
        {
            List<ProcedimentoSinonimo> retorno = new List<ProcedimentoSinonimo>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {


                    ctx.ProcedimentoSinonimos
                        .Where(x => x.Procedimento.ProcedimentoID == ProcedimentoID && x.Ativo == Status.Ativo)
                        .Include(x => x.Procedimento).ThenInclude(x => x.TipoProcedimento)
                        .ThenInclude(x => x.Categoria)
                     .AsParallel().ForAll(item =>
                     {
                         retorno.Add(item);
                     });



                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<ProcedimentoSinonimo> GetProcedimentoSinonimo()
        {
            List<ProcedimentoSinonimo> retorno = new List<ProcedimentoSinonimo>();
            try
            {
                using (var ctx = contexto.CreateDbContext(null))
                {

                    ctx.ProcedimentoSinonimos
                    .Where(x => x.Ativo == Status.Ativo)
                    .Include(x => x.Procedimento).ThenInclude(x => x.TipoProcedimento).ThenInclude(x => x.Categoria)
                    .AsParallel().ForAll(item =>
                    {
                        retorno.Add(item);
                    });


                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
                throw;
            }
            return retorno;
        }

        public IEnumerable<ProcedimentoSinonimo> GetProcedimentoSinonimoPorNome(string nome)
        {
            List<ProcedimentoSinonimo> retorno = new List<ProcedimentoSinonimo>();
            try
            {
                var parametro = nome.ToLower().Trim();

                using (var ctx = contexto.CreateDbContext(null))
                {
                    (from item in ctx.ProcedimentoSinonimos.Include(x => x.Procedimento).ThenInclude(z => z.TipoProcedimento).ThenInclude(z => z.Categoria)
                     join proce in ctx.ProcedimentoEmpresa on item.Procedimento equals proce.Procedimento
                     where item.Ativo == Status.Ativo && proce.Ativo == Status.Ativo &&  item.Nome.ToLower().StartsWith(parametro)
                     select item).AsParallel().ForAll(item =>
                     {
                         retorno.Add(item);
                     });
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert]  Inner Exception [{exception.InnerException}] {Environment.NewLine} Message [{exception.Message}];", exception);
                throw;
            }
            return retorno;
        }

        public PlanoProcedimentoEmpresa VincularPlanoProcedimentoEmpresa(int PlanoID, int ProcedimentoID, int? ConvenioId = null)
        {
            PlanoProcedimentoEmpresa retorno = null;
            try
            {
                Convenio conv = null;
                using (var ctx = contexto.CreateDbContext(null))
                {

                    var procedimentoEmpresa = ctx.ProcedimentoEmpresa.Where(x=> x.ProcedimentoEmpresaID == ProcedimentoID).FirstOrDefault();
                    var plano = ctx.Planos.Find(PlanoID);

                    if (ConvenioId.HasValue)
                        conv = ctx.Convenios.Include(x => x.Planos).Where(c => c.ConvenioId == ConvenioId.Value).FirstOrDefault();

                    retorno = new PlanoProcedimentoEmpresa() { Plano = plano, ProcedimentoEmpresa = procedimentoEmpresa };


                    ctx.Entry(retorno).State = EntityState.Added;
                    ctx.PlanoProcedimentoEmpresas.Add(retorno);
                  
                    ctx.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError($"Ocorreu um erro no metodo [Insert] [{exception.InnerException}] ;", exception);
                throw;
            }
            return retorno;
        }
    }
}
