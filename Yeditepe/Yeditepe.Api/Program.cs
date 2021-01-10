using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Yeditepe.Business.Installers;
using Yeditepe.Business.Repositories;
using Yeditepe.DataAccess.Repositories;

namespace Yeditepe.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {

                builder
                    .RegisterAssemblyTypes(typeof(IServiceRepository<>).Assembly)
                    .Where(x => x.IsInterface)
                    .AsImplementedInterfaces()
                    .InstancePerRequest();

                builder
                    .RegisterAssemblyTypes(typeof(IDalRepository<>).Assembly)
                    .Where(x => x.IsInterface)
                    .AsImplementedInterfaces()
                    .InstancePerRequest();


                builder.RegisterModule(new AutofacModule());

            }).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}