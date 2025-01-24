using FluentValidation;

namespace Shop.Application.Orders.DecreaseItemCount;

public class DecreaseOrderItemCountCommandValidation : AbstractValidator<DecreaseOrderItemCountCommand>
{
    public DecreaseOrderItemCountCommandValidation()
    {
        RuleFor(r => r.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}