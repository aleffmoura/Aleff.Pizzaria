using Aleff.Pizzaria.Domain.Features.Pizzas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Domain.Features.Flavors
{
    public class Flavor : Entity
    {
        public string Name { get; set; }
        public double PreparationTime { get; set; } = 0;
        public IList<Pizza> Pizzas { get; set; }
    }
}
