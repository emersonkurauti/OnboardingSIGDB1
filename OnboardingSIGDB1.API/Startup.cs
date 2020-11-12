using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;
using OnboardingSIGDB1.Domain.Services.Empresas;
using OnboardingSIGDB1.Domain.Services.Cargos;
using System;
using OnboardingSIGDB1.Domain.Services.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using OnboardingSIGDB1.Domain.Services.FuncionariosCargo;
using OnboardingSIGDB1.Domain.AutoMapper;
using System.Linq;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Data.Repositories;
using OnboardingSIGDB1.Domain.Services.FuncionariosCargos;

namespace OnboardingSIGDB1.API
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureAutoMapper.Initialize();

            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepository<Cargo>, Repository<Cargo>>();
            services.AddScoped<IRepository<Empresa>, Repository<Empresa>>();
            services.AddScoped<IRepository<FuncionarioCargo>, Repository<FuncionarioCargo>>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            services.AddScoped<IConsultarFuncionarioCargo, ConsultarFuncionarioCargo>();
            services.AddScoped<IConsultaFuncionario, ConsultaFuncionario>();

            services.AddScoped<IGravarEmpresaService, GravarEmpresaService>();
            services.AddScoped<IRemoverEmpresaService, RemoverEmpresaService>();
            services.AddScoped<IGravarCargoService, GravarCargoService>();
            services.AddScoped<IRemoverCargoService, RemoverCargoService>();
            services.AddScoped<IGravarFuncionarioService, GravarFuncionarioService>();
            services.AddScoped<IRemoverFuncionarioService, RemoverFuncionarioService>();
            services.AddScoped<IGravarFuncionarioCargoService, GravarFuncionarioCargoService>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "OnBoardingSIGDB1",
                        Version = "v1",
                        Description = "OnBoardingSIGDB1"
                    });
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("v1/swagger.json", "OnBoardingSIGDB1 V1");
                });
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
            app.Use(async(context, next) => {
                await next.Invoke();
                string method = context.Request.Method;
                var allowedMethodsToCommit = new string[] { "POST", "PUT", "DELETE" };

                if (!allowedMethodsToCommit.Contains(method))
                    return;

                var notificationContext = (NotificationContext)context.RequestServices.GetService(typeof(NotificationContext));
                if (!notificationContext.HasNotifications)
                {
                    var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
                    unitOfWork.Commit();
                }
            });
        }
    }
}
