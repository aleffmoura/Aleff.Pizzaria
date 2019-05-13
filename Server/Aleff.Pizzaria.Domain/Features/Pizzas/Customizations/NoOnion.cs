using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Domain.Features.Pizzas.Customizations
{
    public class NoOnion : ICustom
    {
        public double GetAditionalTime() => 0;
        public double GetValue() => 0;
    }
}
