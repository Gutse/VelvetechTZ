using Autofac;

namespace VelvetechTZ.Core.Core
{
    public static class CoreContainerConfigurator
    {
        public static void ConfigureCoreContainer(this ContainerBuilder builder, string environmentName)
        {
            builder.RegisterModule(new AutoMapperModule());
        }
    }
}
