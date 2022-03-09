using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Agenda.Infrastruct.Context;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using Agenda.WebApplication.Configs;
using Agenda.Application.Services;
using Agenda.Application.IServices;
using Agenda.Infrastruct.Repository;
using Agenda.Infrastruct.IRepository;

namespace Agenda.WebApplication
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
            var connection = Configuration["ConnectionStrings:DefaultConection"];
            services.AddDbContext<AgendaContext>(options => options.UseSqlServer(connection));

            services.AddControllersWithViews();


            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR"), new CultureInfo("pt-BR") };
            });

            //Mapeando os services e repositorys
            services.AddTransient<IAgendaService, AgendaService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IProcedimentoService, ProcedimentoService>();

            services.AddTransient<IAgendaRepository, AgendaRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IProcedimentoRepository, ProcedimentoRepository>();

            services.AddMvc();
            services.AddCors();
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
