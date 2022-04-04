namespace CuidadosModernos.Domain.Usuarios
{
    public abstract class Persona : Entity
    {
        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public string DNI { get; private set; }

        public string Telefono { get; private set; }
    }
}
