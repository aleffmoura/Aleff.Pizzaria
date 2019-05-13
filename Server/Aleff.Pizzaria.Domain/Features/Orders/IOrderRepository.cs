using Aleff.Pizzaria.Infra.Cross.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Domain.Features.Orders
{
    public interface IOrderRepository
    {
        Task<Result<Exception, Order>> Create(Order order);
        Task<Result<Exception, Order>> GetById(int id);
        Task<Result<Exception, Unit>> Update(Order order);
    }
}
