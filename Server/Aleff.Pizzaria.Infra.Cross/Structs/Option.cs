using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Infra.Cross.Structs
{
    using static Helpers;

    /// <summary>
    /// Essa classe deve ser usada quando queremos representar um objeto de retorno que pode ser nulo.
    ///
    /// Ex: bool b = false ou true;
    /// Ex: Option<bool> b = IsSome indica que o Value é false ou true; IsNone indica que é null;
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial struct Option<T>
    {
        public T Value { get; internal set; }
        public bool IsSome { get; }
        public bool IsNone => !IsSome;
        public Option(T value, bool isSome)
        {
            Value = value;
            IsSome = isSome;
        }
        public TR Match<TR>(Func<T, TR> some, Func<TR> none) => IsSome ? some(Value) : none();
        public static readonly Option<T> None = new Option<T>();
        public static implicit operator Option<T>(T value) => Some(value);
        public static implicit operator Option<T>(NoneType _) => None;
        public static Option<T> Of<T>(T value) => new Option<T>(value, value != null);
    }
    public struct NoneType { }
    public static partial class Helpers
    {
        public static Option<T> Some<T>(T value) => Option<T>.Of(value);
    }
}
