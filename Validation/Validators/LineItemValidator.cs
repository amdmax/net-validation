using DataValidation.ViewModels;
using FluentValidation;

namespace DataValidation.Validators
{
    public class LineItemValidator: AbstractValidator<LineItemViewModel>
    {
        public LineItemValidator()
        {
            RuleFor(x => x.Name).Length(3, 15);
            RuleFor(x => x.PricePerItem).GreaterThan(0);
            RuleFor(x => x.Qty).GreaterThan(0);
        }
    }
}