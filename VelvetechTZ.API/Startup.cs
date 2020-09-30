using System;
using System.IO;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VelvetechTZ.Core.Core;

namespace VelvetechTZ.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment currentEnvironment;
        private readonly IConfiguration configuration;
        public ILifetimeScope? AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment currentEnvironment)
        {
            this.currentEnvironment = currentEnvironment;
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Velvetech TZ api",
                    Version = "v1",

                    Description = "A simple example ASP.NET Core Web API",
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                });

            services.AddCors(options =>
            {
                options.AddPolicy("default", builder => builder.AllowAnyOrigin() // just for this TZ allow any origins
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST", "PUT", "OPTIONS"));
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureCoreContainer(currentEnvironment.EnvironmentName);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("default");

            if (env.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Velvetech TZ API V1"));

                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
