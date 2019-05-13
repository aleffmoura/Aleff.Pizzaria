using Aleff.Pizzaria.Domain.Exceptions;
using Aleff.Pizzaria.Domain.Features.Orders;
using Aleff.Pizzaria.Infra.Cross.Structs;
using Aleff.Pizzaria.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Infra.Data.Features.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private PizzariaDbContext _context;
        public OrderRepository(PizzariaDbContext context)
        {
            _context = context;
        }
        public async Task<Result<Exception, Order>> Create(Order order)
        {
            order.Pizza = _context.Pizzas.FirstOrDefault(p => p.Id == order.Pizza.Id);
            order.PizzaId = order.Pizza.Id;
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Result<Exception, Order>> GetById(int id)
        {
            var order = await _context.Orders.Where(o => o.Id == id)
                                            .Include(x => x.Pizza.Size)
                                            .Include(x => x.Pizza.Flavor)
                                            .Include(x => x.Pizza)
                                            .FirstOrDefaultAsync();

            if (order == null)
                return new NotFoundException();

            return order;
        }

        public async Task<Result<Exception, Unit>> Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Unit.Successful;
        }
    }
}
