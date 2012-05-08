using AutoMapper;
using Autofac;
using DataValidation.Common;

namespace DataValidation.Modules
{
    public class AutoMapperConfigurationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ValidationMapper>().AsImplementedInterfaces();
        }
    }
}