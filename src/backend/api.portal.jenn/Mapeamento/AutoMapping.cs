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
            CreateMap<DTO.Logon, LogonViewModel>();
            CreateMap<LogonViewModel, DTO.Logon>();

            CreateMap<DTO.Convenio, ConvenioViewModel>();
            CreateMap<ConvenioViewModel, DTO.Convenio>();

            CreateMap<DTO.Plano, PlanoViewModel>();
            CreateMap<PlanoViewModel, DTO.Plano>();

            CreateMap<DTO.Empresa, EmpresaViewModel>();
            CreateMap<EmpresaViewModel, DTO.Empresa>();


            CreateMap<DTO.Procedimento, ProcedimentoViewModel>();
            CreateMap<ProcedimentoViewModel, DTO.Procedimento>();

            CreateMap<DTO.ProcedimentoEmpresa, ProcedimentoEmpresaViewModel>();
            CreateMap<ProcedimentoEmpresaViewModel, DTO.ProcedimentoEmpresa>();


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
