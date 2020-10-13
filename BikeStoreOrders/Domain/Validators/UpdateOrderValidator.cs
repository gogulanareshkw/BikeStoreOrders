using BikeStoreOrders.Application.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Domain.Validators
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderRequestDto>
    {
        public UpdateOrderValidator()
        {
            RuleFor(c => c.OrderId).NotEmpty().NotNull();
            RuleFor(c => c.OrderItemId).NotEmpty().NotNull();
            RuleFor(c => c.CustomerId).NotEmpty().NotNull();
            RuleFor(c => c.StaffId).NotEmpty().NotNull();
            RuleFor(c => c.StoreId).NotEmpty().NotNull();
            RuleFor(c => c.ProductId).NotEmpty().NotNull();
            RuleFor(c => c.Quantity).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(c => c.OrderStatus).NotEmpty().NotNull();

        }
    }
}
