using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<CustomerResponseDto>
    {
        public CustomerRequestDto CustomerRequestDto { get; set; }
    }
}
