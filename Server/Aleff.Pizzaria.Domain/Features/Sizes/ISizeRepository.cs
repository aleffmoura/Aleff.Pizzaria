using Aleff.Pizzaria.Infra.Cross.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Domain.Features.Sizes
{
    public interface ISizeRepository
    {
        Task<Result<Exception, Size>> CreateAsync(Size size);
        Task<Result<Exception, Size>> GetBySize(ESize size);
    }
}
