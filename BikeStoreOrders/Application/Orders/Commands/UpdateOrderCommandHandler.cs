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
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderResponseDto>
    {
        private readonly IConfiguration _configuration;
        private readonly IDataContextFactory _dataContextFactory;
        private readonly IMapper _mapper;
        public UpdateOrderCommandHandler(IDataContextFactory dataContextFactory, IMapper mapper, IConfiguration configuration)
        {
            _dataContextFactory = dataContextFactory ?? throw new ArgumentNullException(nameof(dataContextFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<UpdateOrderResponseDto> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var OrderId = new SqlParameter("@OrderId", SqlDbType.Int)
            {
                Value = request.UpdateOrderRequestDto.OrderId
            };
            var OrderItemId = new SqlParameter("@OrderItemId", SqlDbType.Int)
            {
                Value = request.UpdateOrderRequestDto.OrderItemId
            };
            var CustId = new SqlParameter("@CustId", SqlDbType.Int)
            {
                Value = request.UpdateOrderRequestDto.CustomerId
            };
            var StaffId = new SqlParameter("@StaffId", SqlDbType.Int)
            {
                Value = request.UpdateOrderRequestDto.StaffId
            };
            var StoreId = new SqlParameter("@StoreId", SqlDbType.Int)
            {
                Value = request.UpdateOrderRequestDto.StoreId
            };
            var ProductId = new SqlParameter("@ProductId", SqlDbType.Int)
            {
                Value = request.UpdateOrderRequestDto.ProductId
            };
            var Quantity = new SqlParameter("@Quantity", SqlDbType.Int)
            {
                Value = request.UpdateOrderRequestDto.Quantity
            };
            var OrderStatus = new SqlParameter("@OrderStatus", SqlDbType.VarChar, 255)
            {
                Value = request.UpdateOrderRequestDto.OrderStatus
            };

            //var ShippedDate = new SqlParameter("@ShippedDate", SqlDbType.DateTime2)
            //{
            //    Value = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("AppSettings:ExpectingDeliveryInDays"))
            //};
            var IsSuccess = new SqlParameter("@IsError", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            var ResponseMessage = new SqlParameter("@ResponseMessage", SqlDbType.VarChar, 255)
            {
                Direction = ParameterDirection.Output
            };


            bool? isSuccess = null;
            string message = "";
            using var dbcontext = _dataContextFactory.SpawnDbContext();
            var result = await dbcontext.Database.ExecuteSqlInterpolatedAsync($"EXEC updateOrderDetails @OrderId={OrderId.Value}, @OrderItemId={OrderId.Value}, @CustId={CustId.Value}, @StaffId={StaffId.Value}, @StoreId={StoreId.Value}, @ProductId={ProductId.Value}, @Quantity={Quantity.Value}, @OrderStatus={OrderStatus.Value}, @IsSuccess={IsSuccess} out, @ResponseMessage={ResponseMessage} out");
            if (IsSuccess.Value != DBNull.Value)
            {
                isSuccess = (bool)IsSuccess.Value;
            }
            if (ResponseMessage.Value != DBNull.Value)
            {
                message = (string)ResponseMessage.Value;
            }
            await dbcontext.SaveChangesAsync().ConfigureAwait(false);
            var entity = new OrderResults
            {
                Success = isSuccess,
                Message = message
            };
            return _mapper.Map<UpdateOrderResponseDto>(entity);



        }
    }
}
