using CERent.Account.API.Helpers;
using CERent.Account.Lib.Application.Models;
using CERent.Account.Lib.Domain;
using CERent.Core.Lib.Api;
using CERent.Core.Lib.Api.Middleware;
using CERent.Core.Lib.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.API
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.ConfigureDependencies(Configuration);

            services.ConfigureAppSetting(Configuration);

            services.AddControllers();

            base.CommonConfigureServices("Account", services);

            services.ConfigureDbContext(Configuration);

            


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application API", Version = "v1" });

            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        In = ParameterLocation.Header,
            //        Description = "Please insert JWT with Bearer into field",
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.ApiKey
            //    });

            //    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            //    //c.AddSecurityRequirement(new OpenApiSecurityRequirement {
            //    //{
            //    //    new OpenApiSecurityScheme
            //    //    {
            //    //        Reference = new OpenApiReference
            //    //        {
            //    //            Type = ReferenceType.SecurityScheme,
            //    //            Id = "Bearer"
            //    //        }
            //    //    },
            //    //    new string[] { }
            //    //}});
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<CommonHeadersMiddleware>();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(
             options =>
             {
                 foreach (var description in provider.ApiVersionDescriptions)
                 {
                     options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                 }
             });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
