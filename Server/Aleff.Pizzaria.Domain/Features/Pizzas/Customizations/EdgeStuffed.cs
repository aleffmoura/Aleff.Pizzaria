using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Domain.Features.Pizzas.Customizations
{
    public class EdgeStuffed : ICustom
    {
        public double GetAditionalTime() => 5;
        public double GetValue() => 5;
    }
}
