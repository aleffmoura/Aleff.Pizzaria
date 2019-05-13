using Aleff.Pizzaria.Domain.Features.Pizzas;
using Aleff.Pizzaria.Infra.Cross.Structs;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unit = Aleff.Pizzaria.Infra.Cross.Structs.Unit;

namespace Aleff.Pizzaria.Application.Features.Pizzas.Handlers
{

    public class PizzaUpdate
    {
        public class Command : IRequest<Result<Exception, Unit>>
        {
            public int Id { get; set; }
            public IList<string> Customizations { get; set; }

            public virtual ValidationResult Validate()
            {
                return new Validator().Validate(this);
            }

            class Validator : AbstractValidator<Command>
            {
                public Validator()
                {

                    RuleFor(ps => ps.Customizations)
                           .ForEach(x => x.Must(a => a.Equals("Bacon", StringComparison.OrdinalIgnoreCase) ||
                                                     a.Equals("NoOnion", StringComparison.OrdinalIgnoreCase) ||
                                                     a.Equals("EdgeStuffed", StringComparison.OrdinalIgnoreCase)
                                                ));
                }
            }
        }

        public class Handler : IRequestHandler<Command, Result<Exception, Unit>>
        {
            private readonly IPizzaRepository _repository;

            public Handler(IPizzaRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result<Exception, Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var pizzaCallBack = await _repository.GetById(request.Id);
                if (pizzaCallBack.IsFailure)
                    return pizzaCallBack.Failure;

                var pizza = pizzaCallBack.Success;
                Mapper.Map(request, pizza);

                return await _repository.Update(pizza);
            }
        }
    }
}
