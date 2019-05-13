using Aleff.Pizzaria.Domain.Exceptions;
using Aleff.Pizzaria.Domain.Features.Sizes;
using Aleff.Pizzaria.Infra.Cross.Structs;
using Aleff.Pizzaria.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Infra.Data.Features.Sizes
{
    public class SizeRepository : ISizeRepository
    {
        private PizzariaDbContext _context;
        public SizeRepository(PizzariaDbContext context)
        {
            _context = context;
        }
        public async Task<Result<Exception, Size>> CreateAsync(Size size)
        {
            var newSizes = _context.Sizes.Add(size).Entity;
            await _context.SaveChangesAsync();

            return newSizes;
        }

        public async Task<Result<Exception, Size>> GetBySize(ESize esize)
        {
            var size = await _context.Sizes
                                     .Where(x => x.ESize == esize)
                                     .FirstOrDefaultAsync();
            if (size == null)
                return new NotFoundException();

            return size;

        }
    }
}