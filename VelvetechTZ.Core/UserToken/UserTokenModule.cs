using Autofac;

namespace VelvetechTZ.Core.UserToken
{
    public class UserTokenModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserTokenService>().As<IUserTokenService>();
            builder.Register<IUserTokenRepository>(c => new UserTokenRepository(c.Resolve<IDbOperation>())).As<IUserTokenRepository>();
        }
    }
}
