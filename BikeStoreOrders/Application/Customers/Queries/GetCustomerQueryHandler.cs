using AutoMapper;
using BikeStoreOrders.Application.Common.Brokers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Customers.Queries
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, IEnumerable<CustomerResponseDto>>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CustomerResponseDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            using var dbContext = _dataContextFactory.SpawnDbContext();
            var list = await dbContext.Customers.Include(x=> x.Orders).ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<CustomerResponseDto>>(list);
        }

    }
}
