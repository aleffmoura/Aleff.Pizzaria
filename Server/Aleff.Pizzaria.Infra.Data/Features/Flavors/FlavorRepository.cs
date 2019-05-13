using Aleff.Pizzaria.Domain.Exceptions;
using Aleff.Pizzaria.Domain.Features.Flavors;
using Aleff.Pizzaria.Domain.Features.Sizes;
using Aleff.Pizzaria.Infra.Cross.Structs;
using Aleff.Pizzaria.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Infra.Data.Features.Flavors
{
    public class FlavorRepository : IFlavorRepository
    {
        private PizzariaDbContext _context;
        public FlavorRepository(PizzariaDbContext context)
        {
            _context = context;
        }
        public async Task<Result<Exception, Flavor>> Create(Flavor flavor)
        {
            var newFlavor = _context.Flavors.Add(flavor).Entity;
            await _context.SaveChangesAsync();

            return newFlavor;
        }
        public async Task<Result<Exception, Flavor>> GetByFlavorName(string flavor)
        {
            var flavorCallBack = await _context.Flavors
                                                .Where(x => x.Name.Equals(flavor, StringComparison.OrdinalIgnoreCase))
                                                .FirstOrDefaultAsync();

            if (flavorCallBack == null)
                return new NotFoundException();

            return flavorCallBack;
        }
    }
}
