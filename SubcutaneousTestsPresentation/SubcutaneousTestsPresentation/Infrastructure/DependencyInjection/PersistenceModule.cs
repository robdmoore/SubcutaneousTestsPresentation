using Autofac;
using SubcutaneousTestsPresentation.Infrastructure.Database;

namespace SubcutaneousTestsPresentation.Infrastructure.DependencyInjection
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SubcutaneousTestsPresentationDbContext>()
                .InstancePerLifetimeScope();
        }
    }
}