using CERent.Account.Lib.Application.Models;
using CERent.Account.Lib.Application.Services;
using CERent.Account.Lib.Domain;
using CERent.Account.Lib.Domain.Services;
using CERent.Core.Lib.Settings;
using CERent.Core.Lib.Utils;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CERent.Account.API.Helpers
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
        }

        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Application services
            services.TryAddTransient<ILoginService, LoginService>();

            //Domain services
            services.TryAddTransient<IUserService, UserService>();

            //Other
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddTransient<IEncryptionUtil, EncryptionUtil>();
            services.TryAddTransient<ICacheProvider, CacheProvider>();
            
            services.Add(ServiceDescriptor.Singleton<IDistributedCache, RedisCache>());
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetSection("Redis")["ConnectionString"];
            });

            services.AddTransient<UserAuthenticateResult>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var user = accessor.HttpContext.Items["User"] as UserAuthenticateResult;

                if (user == null)
                {
                    if (accessor.HttpContext.Request.Headers.ContainsKey("Authorization"))
                    {
                        string token = accessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
                        return new UserAuthenticateResult();
                    }

                    return new UserAuthenticateResult();
                }

                //var loginTokenInfo = JsonConvert.DeserializeObject<LoginTokenInfo>(loginTokenClaim.Value);
                return user;
            });
        }

        public static void ConfigureAppSetting(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSetting>(options => configuration.GetSection("JwtSetting").Bind(options));
            services.Configure<RabbitMqSetting>(options => configuration.GetSection("RabbitMq").Bind(options));
            //services.Configure<JwtSetting>(options => configuration.GetSection("JwtSetting").Bind(options));
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
           //services.AddDbContext<AccountDbContext>(
           //     options => options.UseSqlServer(configuration.GetConnectionString("ECRent_Account")));

            services.AddDbContext<AccountDbContext>(
                options => options.UseInMemoryDatabase(databaseName: "AccountDbContext"));
        }

        public static void ConfigureRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var _rabbitMqSetting = configuration.GetSection("RabbitMq").Get<RabbitMqSetting>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<EventConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host($"{_rabbitMqSetting.Url}/{_rabbitMqSetting.VirtualHost}/", hst =>
                    {
                        hst.Username(_rabbitMqSetting.UserName);
                        hst.Password(_rabbitMqSetting.Password);
                    });

                    cfg.ReceiveEndpoint("event-listener", e =>
                    {
                        e.ConfigureConsumer<EventConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}
