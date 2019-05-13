using Aleff.Pizzaria.Domain.Features.Pizzas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Domain.Features.Sizes
{
    public enum ESize
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
    public class Size : Entity
    {
        public ESize ESize { get; set; }
        public double PreparationTime { get; set; } = 0;
        public double Value { get; set; } = 0;
        public IList<Pizza> Pizzas { get; set; }
    }
}
