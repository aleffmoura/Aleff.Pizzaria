using Aleff.Pizzaria.Domain.Features.Orders;
using Aleff.Pizzaria.Infra.Cross.Structs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Application.Features.Orders.Handlers
{
    public class OrderDetail
    {
        public class Query : IRequest<Result<Exception, Order>>
        {
            public int Id { get; private set; }
            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, Result<Exception, Order>>
        {
            private readonly IOrderRepository _repository;

            public Handler(IOrderRepository repository)
            {
                _repository = repository;
            }

            public async Task<Result<Exception, Order>> Handle(Query request, CancellationToken cancellationToken)
            {
                var order = await _repository.GetById(request.Id);

                return order;
            }
        }

    }
}
