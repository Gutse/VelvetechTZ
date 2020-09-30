using System.Reflection;
using Autofac;
using AutoMapper;
using Module = Autofac.Module;

namespace VelvetechTZ.Core.Core
{
    public class AutoMapperModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(Assembly.GetExecutingAssembly()));
            builder.Register(_ => configuration.CreateMapper()).As<IMapper>().SingleInstance();
        }
    }
}
