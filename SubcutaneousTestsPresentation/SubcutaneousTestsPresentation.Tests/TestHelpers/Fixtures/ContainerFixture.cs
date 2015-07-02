using System;
using Autofac;
using Autofac.Core.Lifetime;
using SubcutaneousTestsPresentation.Infrastructure.Config;

namespace SubcutaneousTestsPresentation.Tests.TestHelpers.Fixtures
{
    public static class ContainerFixture
    {
        private static readonly IContainer Container;

        static ContainerFixture()
        {
            Container = ContainerConfig.CreateContainer();
        }

        public static ILifetimeScope GetTestLifetimeScope(Action<ContainerBuilder> modifier = null)
        {
            return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag,
                cb => { TestingOverrides(cb); if (modifier != null) modifier(cb); });
        }

        private static void TestingOverrides(ContainerBuilder cb)
        {
            cb.RegisterType<StaticDateTimeProvider>()
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerTestRun();

            cb.RegisterInstance(DatabaseFixture.SqlConnectionString)
                .AsSelf()
                .SingleInstance();
        }
    }
}
