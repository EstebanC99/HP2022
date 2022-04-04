using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cross.Business.Domain
{
    public abstract class ComparableObject
    {
        private const int HashMultiplier = 31;

        [ThreadStatic]
        private static Dictionary<Type, IEnumerable<PropertyInfo>> signaturePropertiesDictionary;

        public override bool Equals(object obj)
        {
            ComparableObject compareTo = obj as ComparableObject;

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            return compareTo != null && this.GetType().Equals(compareTo.GetType()) && this.HasSameObjectSignatureAs(compareTo);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                IEnumerable<PropertyInfo> signatureProperties = this.GetSignatureProperties();

                Int32 hashCode = this.GetType().GetHashCode();

                hashCode = signatureProperties.Select(property => property.GetValue(this))
                                              .Where(value => value != null)
                                              .Aggregate(hashCode, (current, value) => (current * HashMultiplier) ^ value.GetHashCode());

                if (signatureProperties.Any())
                {
                    return hashCode;
                }

                return base.GetHashCode();
            }
        }

        public virtual IEnumerable<PropertyInfo> GetSignatureProperties()
        {
            IEnumerable<PropertyInfo> properties;

            if (signaturePropertiesDictionary == null)
            {
                signaturePropertiesDictionary = new Dictionary<Type, IEnumerable<PropertyInfo>>();
            }

            if (signaturePropertiesDictionary.TryGetValue(this.GetType(), out properties))
            {
                return properties;
            }

            return signaturePropertiesDictionary[this.GetType()] = this.GetTypeSpecificSignatureProperties();
        }

        public virtual Boolean HasSameObjectSignatureAs(ComparableObject compareTo)
        {
            IEnumerable<PropertyInfo> signatureProperties = this.GetSignatureProperties();

            // Se comparan los valores de las propiedades que conforman la firma del objeto entre esta instancia y compareTo,
            // si alguno de los valores no coincide se devuelve false.
            if ((from property in signatureProperties
                 let valueOfThisObject = property.GetValue(this)
                 let valueToCompareTo = property.GetValue(compareTo)
                 where valueOfThisObject != null || valueToCompareTo != null
                 where (valueOfThisObject == null ^ valueToCompareTo == null) || (!valueOfThisObject.Equals(valueToCompareTo))
                 select valueOfThisObject).Any())
            {
                return false;
            }

            // Si se llego a este punto y se encontraron propiedades que conforman la firma, entonces podemos
            // asumir que ha emparejado (es igual); en el caso contrario, si no se encontraron propiedades que conformen
            // la firma del objeto, simplemente se utiliza el comportamiento por defecto de Equals.
            return signatureProperties.Any() || base.Equals(compareTo);
        }

        /// <summary>
        /// Permite a los hijos determinar las propiedades especificas a tener en cuenta para realizar la comparacion
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties();
    }
}
