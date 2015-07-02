using Autofac;
using SubcutaneousTestsPresentation.Infrastructure.Time;

namespace SubcutaneousTestsPresentation.Infrastructure.DependencyInjection
{
    public class TimeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeProvider>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}