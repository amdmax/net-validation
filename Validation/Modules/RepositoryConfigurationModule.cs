using Autofac;
using DataValidation.Common;

namespace DataValidation.Modules
{
    public class RepositoryConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<LineItemRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<CustomerRepository>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<DataAnnotationsRepository>().AsImplementedInterfaces().SingleInstance();
        }
    }
}