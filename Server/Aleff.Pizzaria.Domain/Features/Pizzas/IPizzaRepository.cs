using Aleff.Pizzaria.Domain.Features.Sizes;
using Aleff.Pizzaria.Infra.Cross.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Domain.Features.Pizzas
{
    public interface IPizzaRepository
    {
        Task<Result<Exception, Pizza>> Create(Pizza pizza);
        Task<Result<Exception, Pizza>> GetById(int id);
        Task<Result<Exception, Unit>> Update(Pizza pizza);
    }
}
