using Aleff.Pizzaria.Domain.Exceptions;
using Aleff.Pizzaria.Infra.Cross.Structs;
using Aleff.Pizzaria.Api.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;

namespace Aleff.Pizzaria.Api.Base
{
    public class ApiControllerBase : Controller
    {
        protected IActionResult HandleCommand<TFailure, TSuccess>
            (Result<TFailure, TSuccess> result) where TFailure : Exception
        {
            return result.IsFailure ? HandleFailure(result.Failure) : Ok(result.Success);
        }
        protected IActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
        {
            if (exceptionToHandle is ValidationException)
                return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), (exceptionToHandle as ValidationException).Errors);
            var exceptionPayload = ExceptionPayload.New(exceptionToHandle);
            return exceptionToHandle is BusinessException ?
                StatusCode(HttpStatusCode.BadRequest.GetHashCode(), exceptionPayload) :
                StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), exceptionPayload);
        }
        protected IActionResult HandleQuery<TSource, TResult>(Result<Exception, TSource> result)
        {
            return result.IsSuccess ? Ok(Mapper.Map<TSource, TResult>(result.Success)) : HandleFailure(result.Failure);
        }
    }
}
