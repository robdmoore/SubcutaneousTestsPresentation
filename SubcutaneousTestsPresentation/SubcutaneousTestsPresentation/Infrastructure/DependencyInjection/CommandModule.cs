using Autofac;
using SubcutaneousTestsPresentation.Infrastructure.Commands;

namespace SubcutaneousTestsPresentation.Infrastructure.DependencyInjection
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandExecutor>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof (CommandExecutor).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof (ICommandHandler<>)))
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}