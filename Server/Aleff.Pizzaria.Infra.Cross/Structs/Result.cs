using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Infra.Cross.Structs
{

    using static Helpers;

    /// <summary>
    ///
    /// Essa classe tem o objetivo de fornecer um retorno mais expressivo dos resultados de um função
    /// Ao realizar uma chamada para um Object podemos ter como resultado: Exception, null ou Object
    /// Ex 1: Result<Exception, Customer> t;
    ///     Se IsFailure é True, temos uma instancia de uma Exception
    ///     Se IsSucess é True, temos uma instancia de um Customer
    /// Ex 2: Result<Exception, Success>
    ///     Para Success é necessário fazer o retorno de Unit.Successful
    /// </summary>
    /// <typeparam name="TFailure"></typeparam>
    /// <typeparam name="TSuccess"></typeparam>
    public struct Result<TFailure, TSuccess>
    {
        public TFailure Failure { get; internal set; }
        public TSuccess Success { get; internal set; }
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;
        internal Result(TFailure failure)
        {
            IsFailure = true;
            Failure = failure;
            Success = default(TSuccess);
        }

        internal Result(TSuccess success)
        {
            IsFailure = false;
            Failure = default(TFailure);
            Success = success;
        }

        public TResult Match<TResult>(
                Func<TFailure, TResult> failure,
                Func<TSuccess, TResult> success
            )
            => IsFailure ? failure(Failure) : success(Success);

        public static implicit operator Result<TFailure, TSuccess>(TFailure failure)
            => new Result<TFailure, TSuccess>(failure);

        public static implicit operator Result<TFailure, TSuccess>(TSuccess success)
            => new Result<TFailure, TSuccess>(success);
    }
    /// <summary>
    /// Struct utilizado quando não existir um objeto de retorno.
    /// </summary>
    public struct Unit
    {
        public static Unit Successful { get { return new Unit(); } }
    }
    /// <summary>
    /// Helper para essa classe que auxilia na manipulação das chamadas
    /// </summary>
    public static partial class Helpers
    {
        private static readonly Unit unit = new Unit();
        public static Unit Unit() => unit;
        public static Func<T, Unit> ToFunc<T>(Action<T> action) => o =>
        {
            action(o);
            return Unit();
        };
    }
}
