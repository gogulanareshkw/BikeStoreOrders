using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStoreOrders.Application.Customers;
using BikeStoreOrders.Application.Customers.Commands;
using BikeStoreOrders.Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoreOrders.Web.Controllers
{
    [Route("api")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [Route("customer")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerResponseDto>), 200)]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await _mediator.Send(new GetCustomerQuery()));
        }

        [Route("customer")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerRequestDto customerRequestDto)
        {
            return Ok(await _mediator.Send(new CreateCustomerCommand
            {
                CustomerRequestDto = customerRequestDto
            }));
        }

        [Route("customer")]
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerRequestDto customerRequestDto)
        {
            return Ok(await _mediator.Send(new UpdateCustomerCommand
            {
                CustomerRequestDto = customerRequestDto
            }));
        }


    }
}
