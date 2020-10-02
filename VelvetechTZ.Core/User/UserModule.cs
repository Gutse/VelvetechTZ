using Autofac;

namespace VelvetechTZ.Core.User
{
    public class UserModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
        }
    }
}
