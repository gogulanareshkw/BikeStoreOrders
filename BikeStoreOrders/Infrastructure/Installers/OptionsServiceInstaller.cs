using BikeStoreOrders.Application.Common.Brokers;
using BikeStoreOrders.Application.Common.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreOrders.Infrastructure.Installers
{
    public class OptionsServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration config, string env)
        {
            services.AddOptions();
            services.Configure<DbConnectionSettings>(config.GetSection("DbConnectionSettings"));
            services.AddAuthentication(options =>
                           {
                               options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                               options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                           })
                            .AddJwtBearer(cfg =>
                            {
                                cfg.RequireHttpsMetadata = true;
                                cfg.SaveToken = true;
                                cfg.TokenValidationParameters = new TokenValidationParameters()
                                {
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetSection("AppSettings:Token").Value)),
                                    ValidateAudience = false,
                                    ValidateIssuer = false,
                                    ValidateLifetime = false,
                                    RequireExpirationTime = false,
                                    ClockSkew = TimeSpan.Zero,
                                    ValidateIssuerSigningKey = true
                                };
                            });

        }
    }
}
