using BikeStoreEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(s => s.CustomerId).NotEmpty().NotNull();
            RuleFor(s => s.FirstName).NotEmpty().NotNull();
            RuleFor(s => s.Phone).NotEmpty().NotNull().Length(10);
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.City).NotEmpty().NotNull();
            RuleFor(s => s.State).NotEmpty().NotNull();
            RuleFor(s => s.ZipCode).NotEmpty().NotNull().Length(6);

        }
    }
}
