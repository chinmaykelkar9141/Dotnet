using Autofac;
using postman_demo.Models;
using postman_demo.Services;

namespace postman_demo
{
    public class PostmanDemoModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<RetailBusinessManagementContext>().AsSelf();
        }
    }
}