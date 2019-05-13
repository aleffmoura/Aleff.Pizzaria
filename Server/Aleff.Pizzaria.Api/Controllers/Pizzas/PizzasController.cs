using Aleff.Pizzaria.Api.Base;
using Aleff.Pizzaria.Application.Features.Pizzas.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Api.Controllers.Pizzas
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PizzasController(IMediator mediator) : base()
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PizzaCreate.Command command)
        {
            var result = await _mediator.Send(command);

            return HandleCommand(result);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(PizzaUpdate.Command command)
        {
            var result = await _mediator.Send(command);

            return HandleCommand(result);
        }

    }
}
