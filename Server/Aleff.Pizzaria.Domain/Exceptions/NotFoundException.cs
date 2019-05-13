using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Domain.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException() : base(ErrorCodes.NotFound, "Registry not found")
        {
        }
    }
}
