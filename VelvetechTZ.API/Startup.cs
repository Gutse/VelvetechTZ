using System;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using VelvetechTZ.Core.Authentication;
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
            var defaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddAuthenticationSchemes("default")
                .Build();

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = defaultPolicy;

                options.AddPolicy("feature", new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("feature")
                    .Build());
            });

            services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter(defaultPolicy));
                //options.Filters.Add(new PerfomanceFilter(Log.Logger));
            }).AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

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

            services.AddAuthentication()
                .AddJwtBearer("default", options =>
                {
                    options.SaveToken = true;
                    options.SecurityTokenValidators.Clear();
                    options.SecurityTokenValidators.Add(new CustomTokenValidator(AutofacContainer));
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = JwtTokenIssuer.DefaultIssuerAudience,
                        ValidIssuer = JwtTokenIssuer.DefaultIssuerAudience,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("env.JwtSecretKey"))
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy("default", builder => builder.AllowAnyOrigin() // just for this TZ allow any origins
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
            app.UseAuthentication();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            var authService = AutofacContainer?.Resolve<IAuthenticationService>();
            authService?.SignUp("tzuser", "key.dach@gmail.com", "VeryH@rdP@ssw0rd155");
        }
    }
}
