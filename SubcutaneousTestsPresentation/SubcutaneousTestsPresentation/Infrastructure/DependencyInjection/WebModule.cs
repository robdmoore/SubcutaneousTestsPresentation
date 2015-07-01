using Autofac;
using Autofac.Integration.Mvc;

namespace SubcutaneousTestsPresentation.Infrastructure.DependencyInjection
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(ThisAssembly)
                .PropertiesAutowired();

            builder.RegisterFilterProvider();

            builder.RegisterModule<AutofacWebTypesModule>();
        }
    }
}