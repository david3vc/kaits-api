using Autofac;
using System.Reflection;

namespace Kaits.Infrastructure.Cores.Contexts
{
    public class InfrastructureAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
