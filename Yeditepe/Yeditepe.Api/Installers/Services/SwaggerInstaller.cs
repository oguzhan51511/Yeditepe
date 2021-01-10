using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using YeditepeShop.Api.Installers;
using YtsFramework.NETCore.Utilities.IoC;

namespace Yeditepe.Api.Installers.Services
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api Servisi",
                    Description = ".NET Core 5.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Demo Api Project",
                        Url = new Uri("http://www.google.com"),
                    }
                });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Yetkilendirme, Bearer Şeması kullanarak. Örneğin: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
                c.AddSecurityRequirement(securityRequirement);
                //c.OperationFilter<RequiredHeaderParameter>();
            });
            ServiceTool.Create(services);
        }

        public void InstallConfigure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Service");
                //c.DefaultModelExpandDepth(2);
                //c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);
                //c.DisplayOperationId();
                //c.DisplayRequestDuration();
                //c.DocExpansion(DocExpansion.List);
                c.DocExpansion(DocExpansion.None);
                //c.EnableDeepLinking();
                //c.EnableFilter();
                //c.MaxDisplayedTags(5);
                //c.ShowExtensions();
                //c.EnableValidator();
                //c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Head);
            });
        }
    }
}
