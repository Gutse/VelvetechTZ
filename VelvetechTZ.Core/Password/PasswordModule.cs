using Autofac;

namespace VelvetechTZ.Core.Password
{
    public class PasswordModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordService>().As<IPasswordService>();
        }
    }
}
