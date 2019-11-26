using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Projeto.Presentation.Mvc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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
