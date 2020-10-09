using AutoMapper;
using BikeStoreOrders.Application.Common.Brokers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Orders.Queries
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, IEnumerable<GetOrdersResponseDto>>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetOrdersResponseDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = _dataContextFactory.SpawnDbContext();
            var list = await dbContext.Orders
                .Include(c=> c.Customer)
                                .Include(s => s.Staff)
                .Include(s => s.Store)
                .Include(o => o.OrderItems)
                .ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<GetOrdersResponseDto>>(list);
        }
    }
}
