using Autofac;
using VelvetechTZ.DAL.UserToken;

namespace VelvetechTZ.Core.UserToken
{
    public class UserTokenModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserTokenService>().As<IUserTokenService>().SingleInstance();
            builder.RegisterType<UserTokenRepository>().As<IUserTokenRepository>().SingleInstance();
        }
    }
}
