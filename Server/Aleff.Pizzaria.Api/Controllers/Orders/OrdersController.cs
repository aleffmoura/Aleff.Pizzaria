using Aleff.Pizzaria.Api.Base;
using Aleff.Pizzaria.Application.Features.Orders.Handlers;
using Aleff.Pizzaria.Application.Features.Orders.ViewModels;
using Aleff.Pizzaria.Domain.Features.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Api.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator) : base()
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("{id:int}/detail")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new OrderDetail.Query(id));

            return HandleQuery<Order, OrderDetailViewModel>(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(OrderCreate.Command command)
        {
            var result = await _mediator.Send(command);

            return HandleCommand(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(OrderUpdate.Command command)
        {
            var result = await _mediator.Send(command);

            return HandleCommand(result);
        }
    }

}
