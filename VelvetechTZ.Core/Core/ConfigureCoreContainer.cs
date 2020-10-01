using Autofac;
using VelvetechTZ.Core.Group;
using VelvetechTZ.Core.Student;

namespace VelvetechTZ.Core.Core
{
    public static class CoreContainerConfigurator
    {
        public static void ConfigureCoreContainer(this ContainerBuilder builder, string environmentName)
        {
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterModule(new GroupModule());
            builder.RegisterModule(new StudentModule());
        }
    }
}
