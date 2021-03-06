﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStoreOrders.Application.Orders;
using BikeStoreOrders.Application.Orders.Commands;
using BikeStoreOrders.Application.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoreOrders.Web.Controllers
{
    [Route("api")]
//    [Authorize]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [Route("order")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetOrdersResponseDto>), 200)]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _mediator.Send(new GetOrderQuery()));
        }


        [Route("order")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestDto createOrderRequestDto)
        {
            return Ok(await _mediator.Send(new CreateOrderCommand
            {
                CreateOrderRequestDto = createOrderRequestDto
            }));
        }

        [Route("order")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequestDto updateOrderRequestDto)
        {
            return Ok(await _mediator.Send(new UpdateOrderCommand
            {
                UpdateOrderRequestDto = updateOrderRequestDto
            }));
        }


    }
}
