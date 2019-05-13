using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Domain.Exceptions
{
    /// <summary>
    /// Representa uma exceção de negócio.
    /// É a classe base para a implementação de exceções de negócio.
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(ErrorCodes errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
        public ErrorCodes ErrorCode { get; }
    }
}
