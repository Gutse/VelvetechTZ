using Autofac;

namespace VelvetechTZ.Core.Group
{
    public class GroupModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GroupService>().As<IGroupService>();
            builder.RegisterType<GroupContractValidator>().AsSelf();
        }
    }
}
