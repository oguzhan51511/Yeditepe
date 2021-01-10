using Excepticon.AspNetCore;
using Excepticon.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yeditepe.Api.Middlewares;
using YeditepeShop.Api.Installers;
using YtsFramework.NETCore.Utilities.IoC;

namespace Yeditepe.Api.Installers.Services
{
    public class ExceptionInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddExcepticon();
            ServiceTool.Create(services);
        }

        public void InstallConfigure(IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseExcepticon();
        }
    }
}
