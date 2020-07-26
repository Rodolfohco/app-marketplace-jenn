using api.portal.jenn.DTO;
using api.portal.jenn.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Mapeamento
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<DTO.Logon, NovoLogonViewModel>();
            CreateMap<NovoLogonViewModel, DTO.Logon>();

            CreateMap<DTO.Logon, AutenticarLogonViewModel>();
            CreateMap<AutenticarLogonViewModel, DTO.Logon>();


            CreateMap<DTO.Logon, ConsultaLogonViewModel>();
            CreateMap<ConsultaLogonViewModel, DTO.Logon>();



            CreateMap<DTO.PagamentoProcedimentoEmpresa, NovoPagamentoProcedimentoEmpresaViewModel>();
            CreateMap<NovoPagamentoProcedimentoEmpresaViewModel, DTO.PagamentoProcedimentoEmpresa>();

            CreateMap<DTO.PagamentoProcedimentoEmpresa, ConsultaPagamentoProcedimentoEmpresaViewModel>();
            CreateMap<ConsultaPagamentoProcedimentoEmpresaViewModel, DTO.PagamentoProcedimentoEmpresa>();


            CreateMap<DTO.Grupo, GrupoViewModel>();
            CreateMap<GrupoViewModel, DTO.Grupo>();



            CreateMap<DTO.Empresa, NovaEmpresaViewModel>();
            CreateMap<NovaEmpresaViewModel, DTO.Empresa>();

            CreateMap<DTO.Empresa, ConsultaEmpresaViewModel>();
            CreateMap<ConsultaEmpresaViewModel, DTO.Empresa>();

            

            CreateMap<DTO.Empresa, FilialViewModel>();
            CreateMap<FilialViewModel, DTO.Empresa>();

            CreateMap<DTO.Empresa, NovaFilialViewModel>();
            CreateMap<NovaFilialViewModel, DTO.Empresa>();

            CreateMap<DTO.Roles, RolesViewModel>();
            CreateMap<RolesViewModel, DTO.Roles>();
             



            CreateMap<DTO.Convenio, ConsultaConvenioViewModel>();
            CreateMap<ConsultaConvenioViewModel, DTO.Convenio>();

            CreateMap<DTO.Convenio, ConvenioViewModel>();
            CreateMap<ConvenioViewModel, DTO.Convenio>();

            CreateMap<DTO.Plano, PlanoViewModel>();
            CreateMap<PlanoViewModel, DTO.Plano>();

            CreateMap<DTO.Empresa, EmpresaViewModel>();
            CreateMap<EmpresaViewModel, DTO.Empresa>();

            CreateMap<DTO.Pagamento, PagamentoViewModel>();
            CreateMap<PagamentoViewModel, DTO.Pagamento>();


            CreateMap<DTO.PagamentoProcedimentoEmpresa, PagamentoProcedimentoEmpresaViewModel>();
            CreateMap<PagamentoProcedimentoEmpresaViewModel, DTO.PagamentoProcedimentoEmpresa>();



            CreateMap<DTO.PlanoProcedimentoEmpresa, PlanoProcedimentoEmpresaViewModel>();
            CreateMap<PlanoProcedimentoEmpresaViewModel, DTO.PlanoProcedimentoEmpresa>();



            CreateMap<DTO.Procedimento, ProcedimentoViewModel>();
            CreateMap<ProcedimentoViewModel, DTO.Procedimento>();

            CreateMap<DTO.ProcedimentoEmpresa, ProcedimentoEmpresaViewModel>();
            CreateMap<ProcedimentoEmpresaViewModel, DTO.ProcedimentoEmpresa>();

            CreateMap<DTO.ProcedimentoEmpresa, ConsultaProcedimentoEmpresaViewModel>();
            CreateMap<ConsultaProcedimentoEmpresaViewModel, DTO.ProcedimentoEmpresa>();


            CreateMap<DTO.ProcedimentoEmpresa, NovoProcedimentoEmpresaViewModel>();
            CreateMap<NovoProcedimentoEmpresaViewModel, DTO.ProcedimentoEmpresa>();


            


            CreateMap<DTO.ProcedimentoPergunta, ProcedimentoPerguntaViewModel>();
            CreateMap<ProcedimentoPerguntaViewModel, DTO.ProcedimentoPergunta>();


            CreateMap<DTO.TipoProcedimento, TipoProcedimentoViewModel>();
            CreateMap<TipoProcedimentoViewModel, DTO.TipoProcedimento>();

            CreateMap<DTO.CategoriaProcedimento, CategoriaProcedimentoViewModel>();
            CreateMap<CategoriaProcedimentoViewModel, DTO.CategoriaProcedimento>();

            CreateMap<DTO.UF, UFViewModel>();
            CreateMap<UFViewModel, DTO.UF>();


            CreateMap<DTO.Cidade, CidadeViewModel>();
            CreateMap<CidadeViewModel, DTO.Cidade>();


            CreateMap<RegiaoViewModel, DTO.Regiao>();
            CreateMap<DTO.Regiao, RegiaoViewModel>();


            CreateMap<DTO.Cliente, ClienteViewModel>();
            CreateMap<ClienteViewModel, DTO.Cliente>();


            CreateMap<DTO.FotoEmpresa, FotoEmpresaViewModel>();
            CreateMap<FotoEmpresaViewModel, DTO.FotoEmpresa>();


            CreateMap<DTO.Avalia, AvaliaViewModel>();
            CreateMap<AvaliaViewModel, DTO.Avalia>();

        }

    }
}
