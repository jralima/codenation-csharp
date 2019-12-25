using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AceleraDev.Application.Mapping;
using AutoMapper;
using AceleraDevBase.CrossCutting.IoC;
using AceleraDev.Data.Context;
using Microsoft.EntityFrameworkCore;
using AceleraDev.CrossCutting.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

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
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    // Excluíndo os valores NULL do json, evitando assim que seja trafegado dados desnecessários
                    opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            // Configuração da injeção de dependências
            RegisterIoC.Register(services);

            // Configuração do AutoMapper
            services.AddAutoMapper(typeof(AutoMappingDomainToViewModel));
            services.AddAutoMapper(typeof(AutoMappingViewModelToDomain));

            // Configurando o EntityFramework (SQL SERVER)
            services.AddDbContext<AceleraDevContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configuração do mongoDb
            MongoDbContext.ConnectionString = Configuration.GetConnectionString("mongoAtlas");

            // Configuração da autenticação JWT
            ConfigureAuth(services);

            // Configuração Swagger
            ConfiguracaoSwagger(services);
        }

        private void ConfigureAuth(IServiceCollection services)
        {
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKeyJWT);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.ClaimsIssuer = "aceleraDevBase.api";
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });
        }

        private void ConfiguracaoSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API AceleraDev",
                    Version = "1.0.0",
                    Description = "API para fornecimento de dados para execuçãoo funcionalidades do AceleraDev.</br>",
                    License = new OpenApiLicense
                    {
                        Url = new Uri("http://www.gmail.com")
                    },
                    Contact = new OpenApiContact
                    {
                        Name = "Lacerda Junior",
                        Email = "junior.lacerda16@hotmail.com",
                        Url = new Uri("http://www.gmail.com")
                    }
                });

                config.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "API AceleraDev",
                    Version = "2.0.0",
                    Description = "Versão 2.</br>",
                    License = new OpenApiLicense
                    {
                        Url = new Uri("http://www.gmail.com")
                    },
                    Contact = new OpenApiContact
                    {
                        Name = "Lacerda Junior",
                        Email = "junior.lacerda16@hotmail.com",
                        Url = new Uri("http://www.gmail.com")
                    }
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header usando Bearer scheme. Exemplo: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
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

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "API - AceleraDev V1");
                config.SwaggerEndpoint("/swagger/v2/swagger.json", "API - AceleraDev V2");
                config.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
