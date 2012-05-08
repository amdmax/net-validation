using System;
using System.ComponentModel;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using DataValidation.Common;
using DataValidation.Models;

namespace DataValidation.ModelBinders
{
    [ModelBinderType(typeof(Customer))]
    public class CustomerModelBinder: DefaultModelBinder
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerModelBinder(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var properties = GetModelProperties(controllerContext, bindingContext);

            var idProperty = properties.Find("Id", true);
            var valueProviderResult = bindingContext.ValueProvider.GetValue(idProperty.Name);
       
            int id;

            if (valueProviderResult == null || !int.TryParse(valueProviderResult.AttemptedValue, out id))
                return new Customer();
            
            return _customerRepository.Get(id) ?? new Customer();
        }

        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
                                             PropertyDescriptor propertyDescriptor)
        {
            // avoid of binding this property. 
            // it should be obtained from the database either set by code in the controller

            if(propertyDescriptor.PropertyType == typeof(IEntity))
            {
                return;
            }
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
    }
}