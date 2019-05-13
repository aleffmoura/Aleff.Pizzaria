using Aleff.Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Domain.Features.Pizzas
{
    public class PizzaNotFountException : BusinessException
    {
        public PizzaNotFountException() : base(ErrorCodes.NotFound, "Pizza not found")
        {
        }
    }
}
