using DataValidation.Validators;
using FluentValidation.Attributes;

namespace DataValidation.ViewModels
{
    [Validator(typeof(LineItemValidator))]
    public class LineItemViewModel
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public decimal PricePerItem { get; set; }
        public string Name { get; set; }

        public decimal TotalPerLineItem { get; set; }
    }
}