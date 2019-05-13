using Aleff.Pizzaria.Domain.Exceptions;
using Aleff.Pizzaria.Domain.Features.Pizzas;
using Aleff.Pizzaria.Domain.Features.Sizes;
using Aleff.Pizzaria.Infra.Cross.Structs;
using Aleff.Pizzaria.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Infra.Data.Features.Pizzas
{
    public class PizzaRepository : IPizzaRepository
    {
        private PizzariaDbContext _context;
        public PizzaRepository(PizzariaDbContext context)
        {
            _context = context;
        }
        public async Task<Result<Exception, Pizza>> Create(Pizza pizza)
        {
            var newPizza = _context.Pizzas.Add(pizza).Entity;

            await _context.SaveChangesAsync();

            return newPizza;
        }
        public async Task<Result<Exception, Pizza>> GetById(int id)
        {
            var pizza = await _context.Pizzas.Where(o => o.Id == id)
                                            .Include(x => x.Size)
                                            .Include(x => x.Flavor)
                                            .FirstOrDefaultAsync();
            if (pizza == null)
                return new NotFoundException();

            return pizza;
        }
        public async Task<Result<Exception, Unit>> Update(Pizza pizza)
        {
            _context.Entry(pizza).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Unit.Successful;
        }
    }
}
