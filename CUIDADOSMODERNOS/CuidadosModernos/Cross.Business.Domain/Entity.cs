namespace Cross.Business.Domain
{
    public abstract class Entity<TKey> : IIdentificable<TKey>
    {
        public virtual TKey ID { get; private set; }

        protected Entity() { }

        protected Entity(TKey ID)
        {
            this.ID = ID;
        }

        protected virtual TKey DefaultID()
        {
            return default(TKey);
        }

        public virtual bool IsTransient()
        {
            return this.ID.Equals(this.DefaultID());
        }

    }

    public abstract class Entity : Entity<int>
    {
        protected Entity() { }

        protected Entity(int ID) : base(ID) { }

        public override bool Equals(object obj)
        {
            var entity = obj as Entity;

            if (entity == null)
                return false;

            return this.ID == entity.ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}