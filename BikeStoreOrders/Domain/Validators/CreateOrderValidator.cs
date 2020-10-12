using BikeStoreOrders.Application.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Domain.Validators
{
    public class CreateOrderValidator : AbstractValidator<OrderRequestDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().NotNull();
            RuleFor(c => c.StaffId).NotEmpty().NotNull();
            RuleFor(c => c.StoreId).NotEmpty().NotNull();
            RuleFor(c => c.ProductId).NotEmpty().NotNull();
            RuleFor(c => c.Quantity).NotEmpty().NotNull().GreaterThan(0);

        }

    }
}
