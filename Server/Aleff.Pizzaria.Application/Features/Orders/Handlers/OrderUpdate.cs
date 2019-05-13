using Aleff.Pizzaria.Domain.Features.Orders;
using Aleff.Pizzaria.Domain.Features.Pizzas;
using Aleff.Pizzaria.Infra.Cross.Structs;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Application.Features.Orders.Handlers
{
    public class OrderUpdate
    {
        public class Command : IRequest<Result<Exception, Infra.Cross.Structs.Unit>>
        {
            public int Id { get; set; }

            public virtual ValidationResult Validate()
            {
                return new Validator().Validate(this);
            }

            class Validator : AbstractValidator<Command>
            {
                public Validator()
                {
                }
            }
        }

        public class Handler : IRequestHandler<Command, Result<Exception, Infra.Cross.Structs.Unit>>
        {
            private readonly IOrderRepository _repository;
            private readonly IPizzaRepository _pizzaRepository;

            public Handler(IOrderRepository repository, IPizzaRepository pizzaRepository)
            {
                _repository = repository;
                _pizzaRepository = pizzaRepository;
            }

            public async Task<Result<Exception, Infra.Cross.Structs.Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var orderCallBack = await _repository.GetById(request.Id);
                if (orderCallBack.IsFailure)
                    return orderCallBack.Failure;

                var order = orderCallBack.Success;
                Mapper.Map(request, order);

                return await _repository.Update(order);
            }
        }
    }
}
