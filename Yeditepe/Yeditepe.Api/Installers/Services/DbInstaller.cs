using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yeditepe.DataAccess;
using Yeditepe.DataAccess.Repositories;
using Yeditepe.DataAccess.Seeds;
using YeditepeShop.Api.Installers;
using YtsFramework.NETCore.Utilities.IoC;

namespace Yeditepe.Api.Installers.Services
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<YeditepeContext>(o => o.UseSqlServer(configuration.GetConnectionString("Api")));
            services.AddSingleton<YeditepeContext>();
            services.AddSingleton(typeof(IDalRepository<>), typeof(EfDalRepository<>));
            ServiceTool.Create(services);
        }

        public void InstallConfigure(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<YeditepeContext>();
            context.Database.Migrate();
            SeedManager.SeedData(context);
        }
    }
}
