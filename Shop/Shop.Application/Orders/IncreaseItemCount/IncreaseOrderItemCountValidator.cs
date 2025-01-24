using FluentValidation;

namespace Shop.Application.Orders.IncreaseItemCount;

public class IncreaseOrderItemCountValidator:AbstractValidator<IncreaseOrderItemCount>
{
    public IncreaseOrderItemCountValidator()
    {
        RuleFor(r => r.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}