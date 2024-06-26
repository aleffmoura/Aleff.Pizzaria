﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Domain
{
    public class Entity
    {
        public virtual int Id { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as Entity;
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (Id == 0 || other.Id == 0)
                return false;
            return Id == other.Id;
        }
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }
        public static bool operator !=(Entity a, Entity b) => !(a == b);
        public override int GetHashCode()=> Id.GetHashCode();
        public virtual bool Validate() => true;

    }
}
