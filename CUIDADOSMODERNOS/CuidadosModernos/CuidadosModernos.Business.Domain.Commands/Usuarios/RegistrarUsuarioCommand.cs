using Cross.Business.Domain.Commands;

namespace CuidadosModernos.Business.Domain.Commands.Usuarios
{
    public class RegistrarUsuarioCommand : Command<int>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int PersonaID { get; set; }
    }
}
