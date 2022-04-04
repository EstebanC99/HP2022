using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cross.Business.Domain
{

#pragma warning disable 660, 661

    /// <summary>
    /// Sirve como base para los objetos que son considerados iguales en base a sus valores y no a su identidad, en contraposicion con las Entities.
    /// Es un concepto asociado a DDD.
    /// </summary>
    public abstract class ValueObject : ComparableObject
    {
        protected ValueObject()
        {

        }

        protected override IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties()
        {
            return this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public static Boolean operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static Boolean operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
