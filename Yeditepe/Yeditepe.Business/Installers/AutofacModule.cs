using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using YtsFramework.NETCore.Utilities.Interceptors;
using Module = Autofac.Module;
namespace Yeditepe.Business.Installers
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var x = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(x).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions { Selector = new AspectInterceptorSelector() }).SingleInstance();
        }
    }
}
