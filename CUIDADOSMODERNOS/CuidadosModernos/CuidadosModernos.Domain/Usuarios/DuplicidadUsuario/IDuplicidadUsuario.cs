using CuidadosModernos.Domain.ValueObjects.Usuarios;

namespace CuidadosModernos.Domain.Usuarios.DuplicidadUsuario
{
    public interface IDuplicidadUsuario
    {
        void Validar(RegistrarUsuario usuario);
    }
}