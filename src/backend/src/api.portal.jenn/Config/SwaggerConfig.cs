using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.portal.jenn.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Configuração Api Projeto Jenn Marketplace",
                    Version = "v1",
                    Description = "Api responsável pelos Serviços do Site Jenn",
                    License = new OpenApiLicense { Name = "Free Tecnologia", Url = new Uri("http://www.free-tecnologia.com.br") }

                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Please insert JWT token into field"
                });


                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                                ExternalResource=""

                            }
                        },
                        new string[] { }
                    }
            });
            });

            return services;
        }



        public static void ConfigureSwagger(this IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentacao API v1");
            });

        }
    }
}
