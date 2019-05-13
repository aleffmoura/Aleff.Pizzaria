using Aleff.Pizzaria.Domain.Exceptions;
using Aleff.Pizzaria.Domain.Features.Orders;
using Aleff.Pizzaria.Domain.Features.Pizzas;
using Aleff.Pizzaria.Domain.Features.Sizes;
using Aleff.Pizzaria.Infra.Cross.Structs;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Application.Features.Orders.Handlers
{
    public class OrderCreate
    {
        public class Command : IRequest<Result<Exception, int>>
        {
            public int PizzaId { get; set; }

            public virtual ValidationResult Validate()
            {
                return new Validator().Validate(this);
            }

            class Validator : AbstractValidator<Command>
            {
                public Validator()
                {
                    RuleFor(ps => ps.PizzaId).NotEmpty().NotNull().GreaterThan(0);
                }
            }
        }

        public class Handler : IRequestHandler<Command, Result<Exception, int>>
        {
            private readonly IOrderRepository _repository;
            private readonly IPizzaRepository _pizzaRepository;

            public Handler(IOrderRepository repository, IPizzaRepository pizzaRepository)
            {
                _repository = repository;
                _pizzaRepository = pizzaRepository;
            }

            public async Task<Result<Exception, int>> Handle(Command request, CancellationToken cancellationToken)
            {

                var pizza = await _pizzaRepository.GetById(request.PizzaId);

                if (pizza.IsFailure)
                    return pizza.Failure;

                var order = new Order();
                order.Pizza = pizza.Success;
                order.PizzaId = order.Pizza.Id;

                var createCallback = await _repository.Create(order);

                if (createCallback.IsFailure)
                    return createCallback.Failure;

                return createCallback.Success.Id;
            }

        }
    }
}
