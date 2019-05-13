using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Domain.Features.Pizzas.Customizations
{
    public interface ICustom
    {
        double GetAditionalTime();
        double GetValue();
    }
}
