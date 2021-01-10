using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yeditepe.Api.Installers.Profiles;
using YeditepeShop.Api.Installers;
using YtsFramework.NETCore.Utilities.IoC;

namespace Yeditepe.Api.Installers.Services
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AccountProfile());
            }).CreateMapper());
            ServiceTool.Create(services);
        }

        public void InstallConfigure(IApplicationBuilder app)
        {

        }
    }
}
