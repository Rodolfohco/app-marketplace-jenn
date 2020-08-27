using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.portal.jenn.Contexto;
using crud.ui.portal.jenn.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace crud.ui.portal.jenn
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            var connectionString = string.Empty;

            if (Configuration.GetValue<string>("BancoPrincipal") == "SQLServer")
            {
                services.AddDbContext<DBJennContext>
                (
                     options =>
                     {
                         options.UseSqlServer(Configuration.GetValue<string>("DataBase:SQLConnection"), options => options.EnableRetryOnFailure());
                     }
                );
            }
            else if (Configuration.GetValue<string>("BancoPrincipal") == "MySQL")
            {
                services.AddDbContext<DBJennContext>
                 (
                    options =>
                    {
                        options.UseMySql(Configuration.GetValue<string>("DataBase:MySqlConnection"), options => options.EnableRetryOnFailure());
                        options.EnableDetailedErrors();
                    }
                  );
            }

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(3);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });




            var urlBase = new Uri(this.Configuration.GetValue<string>("urlBaseApi"));
            services.AddHttpContextAccessor();
            services.AddHttpClient<ServiceBase>(c =>
            {
                c.BaseAddress = urlBase;
                c.Timeout = TimeSpan.FromSeconds(5);
            });

            services.AddSingleton<IEmpresaService, EmpresaService>();
            //services.AddSingleton<IProcedimentoEmpresaService, ProcedimentoEmpresaService>();
            //services.AddSingleton<IProdutoService, ProdutoService>();
            //services.AddSingleton<ILogonService, LogonService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews();
            services.AddHttpClient();

            services.AddControllersWithViews();

            services.AddMemoryCache();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }




            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
