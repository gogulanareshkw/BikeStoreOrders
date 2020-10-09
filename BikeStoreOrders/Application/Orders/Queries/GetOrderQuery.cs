using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Orders.Queries
{
    public class GetOrderQuery : IRequest<IEnumerable<GetOrdersResponseDto>>
    {
    }
}
