using AutoMapper;
using BikeStoreOrders.Application.Common.Brokers;
using BikeStoreOrders.Domain.Common;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderResponseDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;
        public CreateOrderCommandHandler(IDataContextFactory dataContextFactory, IMapper mapper, IConfiguration configuration)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<OrderResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var CustId = new SqlParameter("@CustId", SqlDbType.Int)
            {
                Value = request.OrderRequestDto.CustomerId
            };
            var StaffId = new SqlParameter("@StaffId", SqlDbType.Int)
            {
                Value = request.OrderRequestDto.StaffId
            };
            var StoreId = new SqlParameter("@StoreId", SqlDbType.Int)
            {
                Value = request.OrderRequestDto.StoreId
            };
            var ProductId = new SqlParameter("@ProductId", SqlDbType.Int)
            {
                Value = request.OrderRequestDto.ProductId
            };
            var Quantity = new SqlParameter("@Quantity", SqlDbType.Int)
            {
                Value = request.OrderRequestDto.Quantity
            };
            var OrderDate = new SqlParameter("@OrderDate", SqlDbType.DateTime2)
            {
                Value = DateTime.UtcNow
            };
            var ShippedDate = new SqlParameter("@ShippedDate", SqlDbType.DateTime2)
            {
                Value = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("AppSettings:ExpectingDeliveryInDays"))
            };
            var OrderId = new SqlParameter("@OrderId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            var IsSuccess = new SqlParameter("@IsError", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            var ResponseMessage = new SqlParameter("@ResponseMessage", SqlDbType.VarChar, 255)
            {
                Direction = ParameterDirection.Output
            };


            bool? isSuccess = null;
            int? newOrderId = null;
            string message = "";
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            var result = await dbcontext.Database.ExecuteSqlInterpolatedAsync($"EXEC PlaceNewOrder @CustId={CustId.Value}, @StaffId={StaffId.Value}, @StoreId={StoreId.Value}, @ProductId={ProductId.Value}, @Quantity={Quantity.Value}, @OrderDate={OrderDate.Value}, @ShippedDate={ShippedDate.Value}, @NewOrderId={OrderId} out, @IsSuccess={IsSuccess} out, @ResponseMessage={ResponseMessage} out");
            if (IsSuccess.Value != DBNull.Value)
            {
                isSuccess = (bool)IsSuccess.Value;
            }
            if (ResponseMessage.Value != DBNull.Value)
            {
                message = (string)ResponseMessage.Value;
            }
            if (OrderId.Value != DBNull.Value)
            {
                newOrderId = (int)OrderId.Value;
            }
            await dbcontext.SaveChangesAsync().ConfigureAwait(false);
            var entity = new OrderResults {
                OrderId = newOrderId,
                Success = isSuccess,
                Message = message
            };
            return _mapper.Map<OrderResponseDto>(entity);
        }
    }
}
