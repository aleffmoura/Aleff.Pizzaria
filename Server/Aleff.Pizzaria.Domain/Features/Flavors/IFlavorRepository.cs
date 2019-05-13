using Aleff.Pizzaria.Domain.Features.Sizes;
using Aleff.Pizzaria.Infra.Cross.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Domain.Features.Flavors
{
    public interface IFlavorRepository
    {
        Task<Result<Exception, Flavor>> Create(Flavor flavor);
        Task<Result<Exception, Flavor>> GetByFlavorName(string flavor);
    }
}
