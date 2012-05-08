using System.ComponentModel;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using DataValidation.Services;
using DataValidation.ViewModels;

namespace DataValidation.ModelBinders
{
    [ModelBinderType(typeof(CustomerViewModel))]
    public class CustomerViewModelBinder: DefaultModelBinder
    {
        private const string Address = "Address";
        private readonly IAddressValidationService _addressValidationService;

        public CustomerViewModelBinder(IAddressValidationService addressValidationService)
        {
            _addressValidationService = addressValidationService;
        }

        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
                                             PropertyDescriptor propertyDescriptor)
        {
            if(propertyDescriptor.Name == Address)
            {
                ValueProviderResult value = bindingContext.ValueProvider.GetValue(Address);
                
                if(!_addressValidationService.IsValidAddress(value.AttemptedValue))
                {
                    bindingContext.ModelState.AddModelError(Address, "Invalid address provided");
                }
            }
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
    }
}