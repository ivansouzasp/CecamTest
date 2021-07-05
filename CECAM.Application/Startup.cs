using System;
using System.Collections.Generic;
using AutoMapper;
using CECAM.Entities.Security;
using CECAM.IOC.DependencyInjection;
using CECAM.IOC.Mappings;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CECAM.Application
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
            ConfigureRepositories.ConfigureDependenciesRepositories(services, Configuration);
            ConfigureLogicLayer.ConfigureDependenciesLogicLayer(services);

            var assembly = AppDomain.CurrentDomain.Load("CECAM.Repository");
            services.AddMediatR(assembly);

            //Configure mapping
            var configMapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToEntity());
            });
            IMapper mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);

            //Add security context
            var signingConfiguration = new SigningConfiguration();
            services.AddSingleton(signingConfiguration);

            var tokenConfiguration = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(Configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfiguration);
            services.AddSingleton(tokenConfiguration);

            //Add authentication
            services.AddAuthentication(authOtions =>
            {
                authOtions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOtions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfiguration.Key;
                paramsValidation.ValidAudience = tokenConfiguration.Audience;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            //Add sweager context
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                             new OpenApiInfo
                             {
                                 Title = "Cecam Test",
                                 Description = "Cecam test",
                                 Contact = new OpenApiContact
                                 {
                                     Name = "Ivan Souza",
                                     Email = "issouza.personal@gmail.com",
                                     Url = new Uri("http://www.netysofty.com.br")
                                 }
                             });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter with Jwt Token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                                In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s => {
                s.RoutePrefix = string.Empty;
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Project .NetCore 5");
            });
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

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
