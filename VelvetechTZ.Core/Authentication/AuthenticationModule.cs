using Autofac;

namespace VelvetechTZ.Core.Authentication
{
    public class AuthenticationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<JwtTokenIssuer>().As<IJwtTokenIssuer>();
        }
    }
}
