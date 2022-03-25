using System.Diagnostics.CodeAnalysis;

namespace Cross.Business.Domain
{
    public abstract class Aggregate<TKey> : IIdentificable<TKey>
    {
        public virtual TKey ID { get; protected set; }

        protected Aggregate()
        {
            this.ID = default(TKey);
        }

        [SuppressMessage("Microsoft.Usage", "CA2214", Justification = "Propiedad virtual porque se utiliza en los setup de moq.")]
        protected Aggregate(TKey ID)
        {
            this.ID = ID;
        }

        public virtual bool IsTransient()
        {
            return this.ID.Equals(this.DefaultID());
        }

        protected virtual TKey DefaultID()
        {
            return default(TKey);
        }
    }
}
