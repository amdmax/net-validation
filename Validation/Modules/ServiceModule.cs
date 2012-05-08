using Autofac;
using DataValidation.Services;

namespace DataValidation.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<AddressValidationService>().AsImplementedInterfaces();
        }
    }
}