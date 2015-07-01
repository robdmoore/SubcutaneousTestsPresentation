using Autofac;

namespace SubcutaneousTestsPresentation
{
    public static class ContainerConfig
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(ContainerConfig).Assembly);
            return builder.Build();
        }
    }
}