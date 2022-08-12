using CuidadosModernos.Domain.Usuarios;

namespace CuidadosModernos.Domain.Factories.Usuarios
{
    public class UsuarioFactory : IUsuarioFactory
    {
        public Usuario Crear()
        {
            return new Usuario();
        }
    }
}
