﻿using api.portal.jenn.Business;
using api.portal.jenn.Contract;
using api.portal.jenn.Repository;
using api.portal.jenn.Utilidade;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Config
{
    public static class BusinessConfig
    {

        public static void ConfigureBusiness(this IServiceCollection services)
        {

            services.AddSingleton<ILogonRepository, LogonRepository>();
            services.AddSingleton<ILogonBusiness, LogonBusiness>();

            services.AddSingleton<IConvenioRepository, ConvenioRepository>();
            services.AddSingleton<IConvenioBusiness, ConvenioBusiness>();


            services.AddSingleton<IUnidadeBusiness, UnidadeBusiness>();
            services.AddSingleton<IUnidadeRepository, UnidadeRepository>();


            services.AddSingleton<IEmpresaBusiness, EmpresaBusiness>();
            services.AddSingleton<IEmpresaRepository, EmpresaRepository>();

            services.AddSingleton<IPlanoBusiness, PlanoBusiness>();
            services.AddSingleton<ITokenService, TokenService>();


        }

    }

}
