namespace CuidadosModernos.Domain
{
    public abstract class Entity : Cross.Business.Domain.Entity
    {
        public string Descripcion { get; private set; }

        protected Entity()
        { }

        protected Entity(int ID) : base(ID) { }
    }
}
