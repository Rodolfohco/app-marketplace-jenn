using api.portal.jenn.Contexto;
using api.portal.jenn.DTO;
using api.portal.jenn.factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Config
{
    public static class EntityFrameworkConfig
    {
        public static void ConfigureEntityFramework(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CustomContext>
            (
                 options =>
                 {
                     options.UseLazyLoadingProxies().UseMySql(Configuration.GetValue<string>("DataBase:MySqlConnection"));
                     options.EnableDetailedErrors();

                     //options.UseSqlServer(Configuration.GetValue<string>("DataBase:Connection"));
                 }
            );

            services.AddTransient<EmpresaContextFactory>();
            services.AddTransient<ConvenioContextFactory>();
            services.AddTransient<ProcedimentoContextFactory>();


            services.AddDefaultIdentity<Logon>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            }).AddEntityFrameworkStores<CustomContext>()
         .AddDefaultTokenProviders();

        }
        
        public static void ConfigureEntityFramework(this IApplicationBuilder app)
        {
      

        } 

    }
}
