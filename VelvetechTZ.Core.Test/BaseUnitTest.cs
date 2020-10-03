using System;
using Autofac;
using AutoMapper;
using VelvetechTZ.Core.Core;

namespace VelvetechTZ.Core.Test
{
    public class BaseUnitTest
    {
        protected static readonly IMapper mapper;
        protected static readonly IContainer container;
        static BaseUnitTest()
        {
            var builder = new ContainerBuilder();
            builder.ConfigureCoreContainer(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            container = builder.Build();
            mapper = container.Resolve<IMapper>();
        }
    }
}
