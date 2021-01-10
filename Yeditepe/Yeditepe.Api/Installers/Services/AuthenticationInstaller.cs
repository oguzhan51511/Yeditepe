using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using YeditepeShop.Api.Installers;
using YtsFramework.NETCore.Plugins;
using YtsFramework.NETCore.Utilities.IoC;

namespace Yeditepe.Api.Installers.Services
{
    public class AuthenticationInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {

            var options = new YtsFrameworkOptions();
            configuration.GetSection(nameof(YtsFrameworkOptions)).Bind(options);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = options.JwtOptions.Issuer,
                        ValidAudience = options.JwtOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.JwtOptions.SecurityKey)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            ServiceTool.Create(services);
        }

        public void InstallConfigure(IApplicationBuilder app)
        {
            //var service = ServiceTool.ServiceProvider.GetService<IAuthenticationService>();
            //service.LoginAsync(new LoginModel
            //{
            //    Email = "destek@yeditepeshop.com",
            //    Password = "159753"
            //});
        }
    }}
