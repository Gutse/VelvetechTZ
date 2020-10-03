using Autofac;
using Microsoft.EntityFrameworkCore;
using VelvetechTZ.Core.Authentication;
using VelvetechTZ.Core.Group;
using VelvetechTZ.Core.Password;
using VelvetechTZ.Core.Student;
using VelvetechTZ.Core.User;
using VelvetechTZ.Core.UserToken;
using VelvetechTZ.DAL.Repository;

namespace VelvetechTZ.Core.Core
{
    public static class CoreContainerConfigurator
    {
        public static void ConfigureCoreContainer(this ContainerBuilder builder, string environmentName)
        {
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterModule(new GroupModule());
            builder.RegisterModule(new StudentModule());
            builder.RegisterModule(new UserModule());
            builder.RegisterModule(new UserTokenModule());
            builder.RegisterModule(new PasswordModule());
            builder.RegisterModule(new AuthenticationModule());

            builder.RegisterType<DockerDbContext>().As<DbContext>();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}
