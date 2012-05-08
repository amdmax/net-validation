using DataValidation.Controllers;
using DataValidation.Models;
using DataValidation.ViewModels;

namespace DataValidation.Common
{
    public class ValidationMapper : IMapper
    {
        static ValidationMapper()
        {
            AutoMapper.Mapper.CreateMap<LineItem, LineItemViewModel>()
                .ForMember(x=>x.TotalPerLineItem, opt=>opt.MapFrom(y=>y.GetLineItemPrice()))
                ;

            AutoMapper.Mapper.CreateMap<Customer, CustomerViewModel>();
        }

        public T1 Map<T, T1>(T t)
        {
            return AutoMapper.Mapper.Map<T, T1>(t);
        }

        public T1 Map<T, T1>(T t, T1 v)
        {
            AutoMapper.Mapper.DynamicMap(t, v);
            return v;
        }
    }
}