using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.ui.portal.jenn.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
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
