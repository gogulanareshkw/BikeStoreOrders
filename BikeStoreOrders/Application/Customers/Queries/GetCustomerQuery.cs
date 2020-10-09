using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Customers.Queries
{
    public class GetCustomerQuery : IRequest<IEnumerable<CustomerResponseDto>>
    {
    }
}
