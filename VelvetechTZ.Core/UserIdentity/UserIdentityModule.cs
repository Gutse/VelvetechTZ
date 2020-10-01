using Autofac;

namespace VelvetechTZ.Core.UserIdentity
{
    public class UserIdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserIdentityService>().As<IUserIdentityService>();
            builder.RegisterType<UserIdentityRepository>().As<IUserIdentityRepository>();
            builder.Register(_ => new UserIdentityContractValidator());
            builder.RegisterType<UserIdentityGetForUserRequestValidator>().AsSelf();
        }
    }
}
