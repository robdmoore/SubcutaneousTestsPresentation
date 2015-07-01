using System.Linq;
using Autofac;
using SubcutaneousTestsPresentation.Infrastructure.Queries;

namespace SubcutaneousTestsPresentation.Infrastructure.DependencyInjection
{
    public class QueryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QueryExecutor>()
                .As<IQueryExecutor>();

            builder.RegisterGeneric(typeof (QueryAdapter<,>))
                .AsSelf();

            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof (IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}