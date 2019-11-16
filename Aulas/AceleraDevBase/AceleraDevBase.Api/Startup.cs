using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AceleraDev.Application.Mapping;
using AutoMapper;
using AceleraDevBase.CrossCutting.IoC;
using AceleraDev.Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using AceleraDev.Data.Repositories.Base;

namespace AceleraDevBase.Api
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
            services.AddControllers()
                // Desabilitar referência ciricular na serialização dos JSON
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Configuração da injeção de dependências
            RegisterIoC.Register(services);

            // Configuração do AutoMapper
            services.AddAutoMapper(typeof(AutoMappingDomainToViewModel));
            services.AddAutoMapper(typeof(AutoMappingViewModelToDomain));

            // Configurando o EntityFramework (SQL SERVER)
            services.AddDbContext<AceleraDevContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configuração do mongoDb
            MongoDbContext.ConnectionString = Configuration.GetConnectionString("mongoAtlas");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
