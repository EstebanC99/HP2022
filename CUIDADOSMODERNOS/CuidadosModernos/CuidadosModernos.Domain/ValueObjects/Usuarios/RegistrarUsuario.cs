using Cross.Business.Domain;
using CuidadosModernos.Domain.Usuarios;

namespace CuidadosModernos.Domain.ValueObjects.Usuarios
{
    public class RegistrarUsuario : ValueObject
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Persona Persona { get; set; }
    }
}
