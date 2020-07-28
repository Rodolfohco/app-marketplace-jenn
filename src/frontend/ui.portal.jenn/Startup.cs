using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ui.portal.jenn.Handler;
using ui.portal.jenn.Service;

namespace ui.portal.jenn
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            this.Configuration = builder.Build();
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
                //c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                //c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(config =>
              {
                  config.Cookie.Name = "UserLoginCookie";
                  config.LoginPath = "/Home/UserLogin";
                  config.AccessDeniedPath = "/Home/AccessDenied";
              });

            services.AddSingleton<IEmpresaService, EmpresaService>();
            services.AddSingleton<IProcedimentoEmpresaService, ProcedimentoEmpresaService>();

        
            services.AddSingleton<IProdutoService, ProdutoService>();

            services.AddSingleton<ILogonService, LogonService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddSingleton<IContatoService, ContatoService>();
           

            services.AddControllersWithViews();
            services.AddSingleton<ControleCache>();

            services.AddMvc();
            services.AddMemoryCache();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy(cookiePolicyOptions);

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                  name: "PaginaInicial",
                  pattern: "{controller=Home}/{action=Inicio}");

                endpoints.MapControllerRoute(
                    name: "Produtos-por-id",
                    pattern: "{controller=Produtos}/{action=Lista}/{produto}");


                endpoints.MapControllerRoute(
                    name: "produtos-por-localidade+produto",
                    pattern: "{controller=Produto}/{action=Busca}/{produto?}");


                endpoints.MapControllerRoute(
                   name: "Cadastrar-Logon",
                   pattern: "{controller=Home}/{action=Cadastrar}");


                endpoints.MapControllerRoute(
                name: "CentralAjuda",
                pattern: "{controller=Home}/{action=CentralAjuda}");


                endpoints.MapControllerRoute(
                name: "NovoContato",
                pattern: "{controller=Home}/{action=Contato}");


                endpoints.MapControllerRoute(
                name: "MeuPainel",
                pattern: "{controller=Home}/{action=MeuPainel}");


                endpoints.MapControllerRoute(
                name: "MeuPainel",
                pattern: "{controller=Home}/{action=Logout}");
     

                endpoints.MapControllerRoute(
                name: "produto",
                pattern: "{controller=Produto}/{action=Lista}");


                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Inicio}/{id?}");

            });
        }
    }
}
