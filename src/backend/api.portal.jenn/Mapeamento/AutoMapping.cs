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







        }

    }
}
