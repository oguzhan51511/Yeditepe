using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YeditepeShop.Api.Installers;
using YtsFramework.NETCore.Utilities.IoC;

namespace Yeditepe.Api.Installers.Services
{
    public class MvcInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            //services.AddCors(opt =>
            //{
            //    opt.AddPolicy("XXX", builder =>
            //        {
            //            builder.AllowAnyOrigin().WithHeaders(HeaderNames.ContentType, "x-custom-header");
            //        });
            //});

            ServiceTool.Create(services);
        }

        public void InstallConfigure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
           //app.UseCors("XXX");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
