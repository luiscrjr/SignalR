using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Data.Contracts;
using Projeto.Data.Repositories;
using Projeto.Presentation.Mvc.Hubs;

namespace Projeto.Presentation.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //propriedade para leitura do conteudo do arquivo appsettings.json
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //habilitando o signalR
            services.AddSignalR();

            //habilitando o automapper
            services.AddAutoMapper(typeof(Startup));

            //configuração para injeção de dependência
            var connectionString = Configuration.GetConnectionString("BancoSignalR");
            services.AddTransient<IAvaliacaoAtendimentoRepository, IAvaliacaoAtendimentoRepository>
                (map => new AvaliacaoAtendimentoRepository(connectionString));

            //habilitar o Asp.Net MVC
            services.AddMvc();
            services.AddRouting(options => options.LowercaseUrls = true);

            //habilitando autenticação atraves de cookies
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //configuração para habilitar o uso do diretorio wwwroot
            app.UseStaticFiles();

            //autenticação
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();

            //mapear as classes hub do SignalR
            app.UseSignalR(
                routes=>
                {
                    routes.MapHub<AvaliacaoHub>("/avaliacao");
                }
                );

            //configurando o uso de rotas do MVC
            app.UseMvc(
                options =>
                {
                    options.MapRoute(
                            name: "default",
                            template: "{controller=account}/{action=login}/{id?}"
                        );
                }
                );
        }
    }
}
