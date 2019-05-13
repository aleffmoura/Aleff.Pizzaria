using Aleff.Pizzaria.Domain.Features.Flavors;
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

namespace Aleff.Pizzaria.Application.Features.Pizzas.Handlers
{
    public class PizzaCreate
    {

        public class Command : IRequest<Result<Exception, int>>
        {
            public ESize Size { get; set; }
            public string Flavor { get; set; }

            public virtual ValidationResult Validate()
            {
                return new Validator().Validate(this);
            }

            class Validator : AbstractValidator<Command>
            {
                public Validator()
                {
                    RuleFor(ps => ps.Size).NotEmpty().NotNull().IsInEnum();
                    RuleFor(ps => ps.Flavor).NotEmpty().NotNull().MaximumLength(50);
                }
            }
        }

        public class Handler : IRequestHandler<Command, Result<Exception, int>>
        {
            private readonly IPizzaRepository _repository;
            private readonly ISizeRepository _repositorySize;
            private readonly IFlavorRepository _repositoryFlavor;

            public Handler(IPizzaRepository repository,
                            ISizeRepository sizeRepository,
                            IFlavorRepository flavorRepository)
            {
                _repository = repository;
                _repositorySize = sizeRepository;
                _repositoryFlavor = flavorRepository;
            }

            public async Task<Result<Exception, int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var sizeCallBack = await _repositorySize.GetBySize(request.Size);
                if (sizeCallBack.IsFailure)
                    return sizeCallBack.Failure;

                var flavorCallBack = await _repositoryFlavor.GetByFlavorName(request.Flavor);
                if (flavorCallBack.IsFailure)
                    return flavorCallBack.Failure;

                var pizza = new Pizza()
                {
                    FlavorId = flavorCallBack.Success.Id,
                    Flavor = flavorCallBack.Success,
                    SizeId = sizeCallBack.Success.Id,
                    Size = sizeCallBack.Success,
                };
                Mapper.Map(request, pizza);

                var pizzaCallback = await _repository.Create(pizza);
                if (pizzaCallback.IsFailure)
                    return pizzaCallback.Failure;

                return pizzaCallback.Success.Id;
            }

        }
    }
}
