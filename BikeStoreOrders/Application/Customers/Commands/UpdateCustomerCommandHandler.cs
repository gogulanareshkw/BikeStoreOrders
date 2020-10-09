using AutoMapper;
using BikeStoreEntities;
using BikeStoreOrders.Application.Common.Brokers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Customers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerResponseDto>
    {
        public readonly IDataContextFactory _dataContextFactory;
        public readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(IDataContextFactory dataContextFactory, IMapper mapper)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CustomerResponseDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Customer>(request.CustomerRequestDto);
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            dbcontext.Customers.Update(entity);
            await dbcontext.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<CustomerResponseDto>(entity);
        }
    }
}
