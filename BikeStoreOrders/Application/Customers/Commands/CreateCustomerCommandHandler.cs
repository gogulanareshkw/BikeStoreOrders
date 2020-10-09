using AutoMapper;
using BikeStoreEntities;
using BikeStoreOrders.Application.Common.Brokers;
using BikeStoreOrders.Infrastructure.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResponseDto>
    {
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;
        public CreateCustomerCommandHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CustomerResponseDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Customer>(request.CustomerRequestDto);
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            dbcontext.Customers.Add(entity);
            await dbcontext.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<CustomerResponseDto>(entity);
        }
    }
}
