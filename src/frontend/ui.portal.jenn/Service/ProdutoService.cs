using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ui.portal.jenn.Handler;
using ui.portal.jenn.Models;
using ui.portal.jenn.ViewModel;

namespace ui.portal.jenn.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly string Controle;
        private readonly ServiceBase service;
        private readonly IMemoryCache _cache;
        public ProdutoService(ServiceBase _service, IMemoryCache memoryCache)
        {
            this.Controle = "Produto";
            this.service = _service;
            _cache = memoryCache;
        }

        
        public CommandInput Converter(HttpMethod Method, ProdutoViewModel model = null)
        {
            var parametro = new CommandInput();

            if (model != null)
            {
                parametro.Data = new ProdutoViewModel();
                parametro.Data = model;
            }

            parametro.Metodo = Method;
            parametro.UrlAction = this.Controle;

            return parametro;
        }
        public CommandInput Converter(HttpMethod Method, string Action, ProdutoViewModel model = null)
        {
            var parametro = new CommandInput();

            if (model != null)
            {
                parametro.Data = new ProdutoViewModel();
                parametro.Data = model;
            }

            parametro.Metodo = Method;
            parametro.UrlAction = $"{this.Controle}/{Action}?EmpresaID={model.ProdutoID}&nome={model.Produto}";

            return parametro;
        }



        public Task DeletarAsync(Guid EmpresaID)
        {
            throw new NotImplementedException();
        }

        public async Task<CommandResult> Detalhar(Guid ProdutoID)
        {
            try
            {
                var retorno = await this.service.GetAsync(this.Converter(HttpMethod.Get, "Detail",
                    new ProdutoViewModel() { ProdutoID = ProdutoID }));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CommandResult> Novo(ProdutoViewModel model)
        {
            try
            {
                var retorno = await this.service.PostAsync(this.Converter(HttpMethod.Post, model));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CommandResult> Selecionar()
        {
            try
            {
                var retorno = await this.service.GetAsync(this.Converter(HttpMethod.Get));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Task Atualizar(ProdutoViewModel model, Guid EmpresaID)
        {
            throw new NotImplementedException();
        }


        public List<DTOAutocomplete> BuscarProdutos(string produtos)
        {
            List<DTOAutocomplete> listaFinal = new List<DTOAutocomplete>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();
            List<Empresa> listas = new List<Empresa>();
            produtos = produtos.ToLower();


            if (dTOEmpresa.data == null)
                return listaFinal;

            listas = dTOEmpresa.data.Where(e => e.matriz != null).ToList();

            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<Procedimento> procedimentos = procedimentoEmpresas.Select(p => p.procedimento).Where(p=>p.nome.ToLower().Contains(produtos)).ToList();

            foreach (var item in procedimentos)
            {
                if (listaFinal.Find(n => n.label == item.nome) == null)
                {
                    DTOAutocomplete dTOAutocomplete = new DTOAutocomplete();
                    dTOAutocomplete.label = item.nome;
                    dTOAutocomplete.value = item.nome;
                    dTOAutocomplete.id = item.procedimentoID;
                    dTOAutocomplete.tipo = 0;
                    listaFinal.Add(dTOAutocomplete);
                }                    
            }
                

            return listaFinal;
        }

        public List<DTOAutocomplete> BuscarLocalidades(string localidades, string produtos)
        {
            List<DTOAutocomplete> listaFinal = new List<DTOAutocomplete>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            localidades = localidades.ToLower();
            List<Cidade> listasCidades = new List<Cidade>();
            List<Empresa> listas = new List<Empresa>();

            if (dTOEmpresa.data == null)
                return listaFinal;

            listas = dTOEmpresa.data.Where(e => e.matriz != null).ToList();
             
            if(produtos != null)
            {
                produtos = produtos.ToLower();
                listas.ForEach(new Action<Empresa>(delegate (Empresa empresa)
                {
                    if (empresa.procedimentoEmpresas.Select(x => x.procedimento).Where(c => c.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(produtos))) != null)
                    {
                        if (empresa.cidade != null)
                        {   
                            if (empresa.cidade.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidades)))
                            {
                                if (listasCidades.Find(n=> n.nome.Contains(empresa.cidade.nome)) == null)
                                    listasCidades.Add(empresa.cidade);
                            }

                        }
                        
                    }
                }));
            }
            else
            {
                listasCidades = listas.Select(c => c.cidade).Where(p => p != null && p.nome.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(localidades))).ToList();
            }


            foreach (var item in listasCidades)
            {
                if (listaFinal.Find(n => n.label == item.nome) == null)
                {
                    DTOAutocomplete dTOAutocomplete = new DTOAutocomplete();
                    dTOAutocomplete.label = item.nome;
                    dTOAutocomplete.value = item.nome;
                    dTOAutocomplete.id = item.cidadeID;
                    dTOAutocomplete.tipo = 0;
                    listaFinal.Add(dTOAutocomplete);
                }
            }

            return listaFinal;


        }

        public List<Empresa> BuscarProdutosDetalhes(int produto,  string localidade)
        {
            List<Empresa> lista = new List<Empresa>();
            List<Empresa> listasEmpresas = new List<Empresa>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            if(dTOEmpresa.data == null)
                return listasEmpresas;

            lista = dTOEmpresa.data.Where(e => e.matriz != null).ToList();

            if (produto != null)
            {
                lista.ForEach(new Action<Empresa>(delegate (Empresa empresa)
                {
                    if (empresa.procedimentoEmpresas.Select(x => x.procedimento).Where(c => c.procedimentoID == produto).Count() > 0)
                    { 
                        if (localidade == null || (empresa.cidade != null && empresa.cidade.nome.Contains(localidade)))
                        {
                            if (listasEmpresas.Find(n => n.empresaID == empresa.empresaID) == null)
                                listasEmpresas.Add(empresa);
                        }                         
                    }
                }));
            }
            else if(localidade != null)
            {
                localidade = localidade.ToLower();
                listasEmpresas = lista.Where(c => c.cidade != null && c.cidade.nome.ToLower().Contains(localidade)).ToList();
            }
            else
            {
                listasEmpresas = lista;
            }

            listasEmpresas = listasEmpresas.Where(p => p.procedimentoEmpresas.Count() > 0).ToList();

            return listasEmpresas;
        }

        private DTOEmpresa getProcedimentoEmpresa()
        {
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync("http://api.examesemcasa.com.br/api/Empresa").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<DTOEmpresa>(JsonString);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

            private DTOEmpresa getProcedimentoEmpresaLocal()
            {
                using (var client = new HttpClient())
                {
                    //using (var response = client.GetAsync("http://api.examesemcasa.com.br/api/Empresa").Result)
                    //{
                    string JsonString = File.ReadAllText("C:\\Projeto Jenn\\empresa.json");  // Read the contents of the file

                    //if (response.IsSuccessStatusCode)
                    //        {
                    //var JsonString = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<DTOEmpresa>(JsonString);
                    //        }
                    //        else
                    //        {
                    //            return null;
                    //    }
                    //}
                }
            }

        private DTOEmpresa BuscarEmpresas()
        {
            string cacheKey = "DTOEmpresa";
            
            DTOEmpresa dTOEmpresa = getProcedimentoEmpresa();
            /*
              DTOEmpresa dTOEmpresa = _cache.Get<DTOEmpresa>(cacheKey);
            if (dTOEmpresa == null)
            {
                dTOEmpresa = getProcedimentoEmpresa();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(20));
                _cache.Set<DTOEmpresa>(cacheKey, dTOEmpresa, cacheEntryOptions);
            }
            */

            return dTOEmpresa;
        }


        public List<Empresa> BuscarTipoProdutosDetalhes(string tipoproduto)
        {
            List<Empresa> lista = new List<Empresa>();
            List<Empresa> listasEmpresas = new List<Empresa>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();                 
            
            lista = dTOEmpresa.data.ToList();

            if (tipoproduto != null)
            {
                tipoproduto = tipoproduto.ToLower();
                lista.ForEach(new Action<Empresa>(delegate (Empresa empresa)
                {
                    if (empresa.procedimentoEmpresas.Select(x => x.procedimento).Where(c => c.tipoProcedimento.nome.ToLower().Contains(tipoproduto)).Count() > 0)
                    {                        
                        if (listasEmpresas.Find(n => n.empresaID == empresa.empresaID) == null)
                            listasEmpresas.Add(empresa);                       
                    }
                }));
            }

            listasEmpresas = listasEmpresas.Where(p => p.procedimentoEmpresas.Count() > 0).ToList();

            return listasEmpresas;
        }


        public List<TipoProcedimentoViewModel> BuscarTipoProdutos()
        {
            List<TipoProcedimentoViewModel> listaFinal = new List<TipoProcedimentoViewModel>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();
             
            if (dTOEmpresa.data == null)
                return listaFinal;

            List<Empresa> listas = dTOEmpresa.data.Where(e => e.matriz != null).ToList();

            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<Procedimento> procedimentos = procedimentoEmpresas.Select(p => p.procedimento).ToList();


            foreach (var item in procedimentos)
            {
                TipoProcedimentoViewModel tipoProcedimento = new  TipoProcedimentoViewModel();
                tipoProcedimento.Nome = item.tipoProcedimento.nome;
                tipoProcedimento.TipoProcedimentoID = item.tipoProcedimento.tipoProcedimentoID;
                if (listaFinal.Where(t => t.Nome == tipoProcedimento.Nome).Count() == 0)
                    listaFinal.Add(tipoProcedimento);
            }
              
            return listaFinal;
        }

        public List<string> BuscarBairros()
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();
            
            List<Empresa> listas = dTOEmpresa.data.Where(e=>e.matriz != null).ToList();
            listas = listas.Where(p => p.procedimentoEmpresas.Count() > 0).ToList();
            foreach (var item in listas)
                if (item.cidade != null && listaFinal.IndexOf(item.cidade.nome) == -1)
                    listaFinal.Add(item.cidade.nome);
            
            return listaFinal;

        }

        public List<Empresa> BuscarBairroPorDetalhes(List<string> bairros, List<Empresa> empresas = null)
        {
            List<Empresa> lista = new List<Empresa>();
            DTOEmpresa dTOEmpresa = new DTOEmpresa();

            if (empresas != null && empresas.Count() > 0)
                dTOEmpresa.data = empresas;
            else
                dTOEmpresa = BuscarEmpresas();



            for (int i = 0; i < bairros.Count; i++)
            {
                lista.AddRange(dTOEmpresa.data.Where(p => p.cidade != null && p.cidade.nome.ToLower().Contains(bairros[i])).ToList());
            }

            lista = lista.Where(p => p.procedimentoEmpresas.Count() > 0).ToList();

            return lista;
        }

        public List<string> BuscarProcedimentos()
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            if (dTOEmpresa.data == null)
                return listaFinal;

            List<Empresa> listas = dTOEmpresa.data.Where(e => e.matriz != null).ToList();

            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<Procedimento> procedimentos = procedimentoEmpresas.Select(p => p.procedimento).ToList();

            foreach (var item in procedimentos)
            {
                if (listaFinal.Find(n => n == item.nome) == null)
                    listaFinal.Add(item.nome);
            }


            return listaFinal;
        }

        public List<string> BuscarPagamentos()
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();


            if (dTOEmpresa.data == null)
                return listaFinal;

            List<Empresa> listas = dTOEmpresa.data.Where(e => e.matriz != null).ToList();

            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<PagamentoProcedimentoEmpresa> pagamentoProcedimentoEmpresas = procedimentoEmpresas.SelectMany(p => p.pagamentoProcedimentoEmpresas).ToList();

            foreach (var item in pagamentoProcedimentoEmpresas)
            {
                if(item.pagamento != null)
                    if (listaFinal.Find(n => n == item.pagamento.nome) == null)
                        listaFinal.Add(item.pagamento.nome);
            }

            return listaFinal;
        }

        public List<Empresa> BuscarServicosPorDetalhes(List<string> servicos, List<Empresa> empresas = null)
        {
            List<Empresa> lista = new List<Empresa>();
            DTOEmpresa dTOEmpresa = new DTOEmpresa();

            if (empresas != null && empresas.Count() > 0)
                dTOEmpresa.data = empresas;
            else
                dTOEmpresa = BuscarEmpresas();


            dTOEmpresa.data.ToList().ForEach(new Action<Empresa>(delegate (Empresa empresa)
            {
                if (empresa.procedimentoEmpresas != null && empresa.procedimentoEmpresas.Count() > 0)
                {
                    for (int i = 0; i < servicos.Count; i++)
                    {
                        if (empresa.procedimentoEmpresas.Select(x => x.procedimento).Where(c => c.nome.ToLower().Contains(servicos[i])).Count() > 0)
                        {                           
                            if (lista.Find(n => n.empresaID == empresa.empresaID) == null)
                                lista.Add(empresa);                               
                        }
                    }
                }      
            }));

            lista = lista.Where(p => p.procedimentoEmpresas.Count() > 0).ToList();

            return lista;
        }

 
        public List<Empresa> BuscarPagamentosPorDetalhes(List<string> pagamentos, List<Empresa> empresas = null)
        {
            List<Empresa> lista = new List<Empresa>();
            DTOEmpresa dTOEmpresa = new DTOEmpresa();

            if (empresas != null && empresas.Count() > 0)
                dTOEmpresa.data = empresas;
            else
                dTOEmpresa = BuscarEmpresas();


            dTOEmpresa.data.ToList().ForEach(new Action<Empresa>(delegate (Empresa empresa)
            {
                if (empresa.procedimentoEmpresas != null && empresa.procedimentoEmpresas.Count() > 0)
                {
                    for (int i = 0; i < pagamentos.Count; i++)
                    {
                        if (empresa.procedimentoEmpresas.SelectMany(x => x.pagamentoProcedimentoEmpresas).Select(x => x.pagamento).Where(c => c.nome.ToLower().Contains(pagamentos[i])).Count() > 0)
                        {
                            if (lista.Find(n => n.empresaID == empresa.empresaID) == null)
                                lista.Add(empresa);
                        }
                    }
                }
            }));
            lista = lista.Where(p => p.procedimentoEmpresas.Count() > 0).ToList();

            return lista;
        }


        public List<string> BuscarConvenios()
        {
            List<string> listaFinal = new List<string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            List<Empresa> listas = dTOEmpresa.data.ToList();
            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            List<PlanoProcedimentoEmpresa> planoProcedimentoEmpresas = procedimentoEmpresas.SelectMany(p => p.planoProcedimentoEmpresas).ToList();

            foreach (var item in planoProcedimentoEmpresas)
            {
                if (item.plano != null)
                    if (item.plano.convenio != null)
                        if (listaFinal.Find(n => n == item.plano.convenio.nome) == null)
                            listaFinal.Add(item.plano.convenio.nome);
            }

            return listaFinal;
        }


        public List<Empresa> BuscarConvenioPorDetalhes(List<string> convenios, List<Empresa> empresas = null)
        {
            List<Empresa> lista = new List<Empresa>();
            DTOEmpresa dTOEmpresa = new DTOEmpresa();

            if (empresas != null && empresas.Count() > 0)
                dTOEmpresa.data = empresas;
            else
                dTOEmpresa = BuscarEmpresas();



            dTOEmpresa.data.ToList().ForEach(new Action<Empresa>(delegate (Empresa empresa)
            {
                if (empresa.procedimentoEmpresas != null && empresa.procedimentoEmpresas.Count() > 0)
                {
                    if (empresa.procedimentoEmpresas.SelectMany(x => x.planoProcedimentoEmpresas).Count() > 0)
                    {
                        for (int i = 0; i < convenios.Count; i++)
                        {
                            if (empresa.procedimentoEmpresas.SelectMany(x => x.planoProcedimentoEmpresas).Select(x => x.plano.convenio).Where(c => c.nome.ToLower().Contains(convenios[i])).Count() > 0)
                            {
                                if (lista.Find(n => n.empresaID == empresa.empresaID) == null)
                                    lista.Add(empresa);
                            }
                        }
                    }
                }
            }));
            lista = lista.Where(p => p.procedimentoEmpresas.Count() > 0).ToList();
            return lista;
        }

        public PesquisaViewModel BuscarEmpresaPorId(int id, int idProcedimento)
        {
            PesquisaViewModel pesquisaViewModel = new PesquisaViewModel();
            Empresa empresa = new Empresa();
            DTOEmpresa dTOEmpresa = new DTOEmpresa();

            dTOEmpresa = BuscarEmpresas();

            if (dTOEmpresa != null && dTOEmpresa.data != null)
            {
                empresa = dTOEmpresa.data.Where(e => e.empresaID == id).ToList().FirstOrDefault();

                if(empresa != null)
                {
                    pesquisaViewModel.NomeEmpresa = empresa.matriz != null ? empresa.matriz.nome : "";
                    pesquisaViewModel.Localidade = empresa.logradouro;

                    pesquisaViewModel.DescricaoProcedimento = "";
                    IEnumerable<ProcedimentoEmpresa> procedimentoEmpresas = empresa.procedimentoEmpresas.ToList();
                    List<ConsultaAgendaViewModel> consultaAgendaViewModels = new List<ConsultaAgendaViewModel>();

                    string tipoprocedimento = "";
                    int i = 0;
                    foreach (var itemEmp in procedimentoEmpresas)
                    {
                        string operador = "";
                        if (i > 0)
                        {
                            if (i + 1 == procedimentoEmpresas.Count())
                                operador = " e ";
                            else
                                operador = ", ";
                        }

                        if(tipoprocedimento.IndexOf(itemEmp.procedimento.tipoProcedimento.nome + ";") == -1)
                        {
                            pesquisaViewModel.DescricaoProcedimento += operador + itemEmp.procedimento.tipoProcedimento.nome;
                            tipoprocedimento += itemEmp.procedimento.tipoProcedimento.nome + ";";
                        }
                            

                        if (itemEmp.agendas != null && itemEmp.agendas.Count() > 0)
                            consultaAgendaViewModels.AddRange(itemEmp.agendas);

                        i++;
                    }

                    pesquisaViewModel.EmpresaID = empresa.empresaID;

                    pesquisaViewModel.Opiniao = empresa.avaliacoes.Count();
                    pesquisaViewModel.NomeUnidade = empresa.nome;
                    pesquisaViewModel.EnderecoCompleto = empresa.logradouro + ", " + empresa.numero + " - " + empresa.bairro;
                    pesquisaViewModel.EnderecoLoja = empresa.url_loja;
                    pesquisaViewModel.UrlImagem = empresa.imgemFrontEmpresa;
                    pesquisaViewModel.UrlMaps = empresa.maps;

                    Procedimento procedimento = BuscarProdutosPorId(idProcedimento);
                    pesquisaViewModel.Produto = procedimento.nome;
                    pesquisaViewModel.IdProcedimento = procedimento.procedimentoID;

                }

            }
           

            return pesquisaViewModel;
        }


        public Procedimento BuscarProdutosPorId(int produto)
        {
            List<Empresa> lista = new List<Empresa>();
            Procedimento procedimento = new Procedimento();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            if (dTOEmpresa.data == null)
                return procedimento;

            lista = dTOEmpresa.data.Where(e => e.matriz != null).ToList();
            ProcedimentoEmpresa procedimentoEmpresas = lista.SelectMany(pe=>pe.procedimentoEmpresas).Where(p=>p.procedimento.procedimentoID == produto).FirstOrDefault();

            if (procedimentoEmpresas != null)
                procedimento = procedimentoEmpresas.procedimento;

            return procedimento;
        }

        public async Task<CommandResult> SalvarAgendamentoPaciente(AgendamentoViewModel model)
        {
            try
            {
                ConfirmacaoAgendamento confirmacaoAgendamento = new ConfirmacaoAgendamento();


                model.CPF = model.CPF == null ? "" : model.CPF;
                model.CPFSolicitante = model.CPFSolicitante == null ? "" : model.CPFSolicitante;

                if (model.PacienteTitular == "exameparamim")
                    confirmacaoAgendamento.pacienteTitular = true;
                else
                    confirmacaoAgendamento.pacienteTitular = false;

                confirmacaoAgendamento.agendaID = model.AgendaID;
                confirmacaoAgendamento.alergiaReacoes = model.AlgumaAlergia;
                confirmacaoAgendamento.altura = model.Altura;
                confirmacaoAgendamento.carteirinhaConvenio = model.Carteirinha;

                if (model.Contraste == "comcontraste")
                    confirmacaoAgendamento.contraste = true;
                else
                    confirmacaoAgendamento.contraste = false;

                confirmacaoAgendamento.peso = model.Peso;
                confirmacaoAgendamento.planoID = model.PlanoID;
                confirmacaoAgendamento.procedimentoEmpresaID = model.PesquisaViewModel.IdProcedimentoEmpresa;

                confirmacaoAgendamento.cliente = new Cliente();
                confirmacaoAgendamento.cliente.bairro = "";
                confirmacaoAgendamento.cliente.celular = model.Celular;
                confirmacaoAgendamento.cliente.cep = "";
                //confirmacaoAgendamento.cliente.clienteID = model.
                confirmacaoAgendamento.cliente.cpf_cliente = model.CPFSolicitante == null ? "" : model.CPFSolicitante;
                confirmacaoAgendamento.cliente.dtaNascimento = Convert.ToDateTime(model.DataNascimento);
                confirmacaoAgendamento.cliente.logradouro  = "";
                confirmacaoAgendamento.cliente.nome = model.Nome;
                confirmacaoAgendamento.cliente.numero = "";
                confirmacaoAgendamento.cliente.referencia  = "";
                confirmacaoAgendamento.cliente.sexo  = "";
                confirmacaoAgendamento.cliente.sobrenome = model.Sobrenome;
                confirmacaoAgendamento.cliente.telefone  = "";



                confirmacaoAgendamento.paciente = new Paciente();
                confirmacaoAgendamento.paciente.bairro  = "";
                confirmacaoAgendamento.paciente.celular = confirmacaoAgendamento.pacienteTitular == true ? model.Celular : model.CelularPaciente;
                confirmacaoAgendamento.paciente.cep  = "";
                //confirmacaoAgendamento.paciente.pacienteID = model.
                confirmacaoAgendamento.paciente.cpf_paciente = confirmacaoAgendamento.pacienteTitular == true ? model.CPFSolicitante : model.CPF;
                confirmacaoAgendamento.paciente.dtaNascimento = confirmacaoAgendamento.pacienteTitular == true ? Convert.ToDateTime(model.DataNascimento) : Convert.ToDateTime(model.DataNascimento);
                confirmacaoAgendamento.paciente.logradouro  = "";
                confirmacaoAgendamento.paciente.nome = confirmacaoAgendamento.pacienteTitular == true ? model.Nome : model.NomePaciente;
                confirmacaoAgendamento.paciente.numero  = "";
                confirmacaoAgendamento.paciente.referencia  = "";
                confirmacaoAgendamento.paciente.sexo  = "";
                confirmacaoAgendamento.paciente.sobrenome = confirmacaoAgendamento.pacienteTitular == true ? model.Sobrenome : model.SobrenomePaciente;
                confirmacaoAgendamento.paciente.telefone  = "";



                var retorno = await this.service.PostAsync(this.ConverterAgendamento(HttpMethod.Post, "Agenda/ConfirmarAgenda", confirmacaoAgendamento));
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private CommandInput ConverterAgendamento(HttpMethod Method, string Controle = null, ConfirmacaoAgendamento model = null)
        {
            var parametro = new CommandInput();

            if (model != null)
            {
                parametro.Data = new ContatoViewModel();
                parametro.Data = model;
            }

            parametro.Metodo = Method;

            if (!string.IsNullOrEmpty(Controle))
                parametro.UrlAction = Controle;
            else
                parametro.UrlAction = this.Controle;

            return parametro;
        }

        public Dictionary<int,string> BuscarProcedimentosPorTipo(int tipoProcedimentoID)
        {
            Dictionary<int, string> listaFinal = new Dictionary<int, string>();
            DTOEmpresa dTOEmpresa = BuscarEmpresas();

            List<Empresa> listas = dTOEmpresa.data.ToList();
            List<ProcedimentoEmpresa> procedimentoEmpresas = listas.SelectMany(pe => pe.procedimentoEmpresas).ToList();
            procedimentoEmpresas = procedimentoEmpresas.Where(pe => pe.procedimento != null && pe.procedimento.tipoProcedimento != null && pe.procedimento.tipoProcedimento.tipoProcedimentoID == tipoProcedimentoID).ToList();

            foreach (var item in procedimentoEmpresas)
            {
                if (item.procedimento != null)
                    if (!listaFinal.ContainsKey(item.procedimento.procedimentoID))
                        listaFinal.Add(item.procedimento.procedimentoID, item.procedimento.nome);
            }

            return listaFinal;
        }

    }
}
