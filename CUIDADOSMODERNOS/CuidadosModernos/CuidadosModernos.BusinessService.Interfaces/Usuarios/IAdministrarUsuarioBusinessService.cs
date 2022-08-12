using Cross.BusinessService.Interfaces;
using CuidadosModernos.Business.Domain.Commands.Usuarios;

namespace CuidadosModernos.BusinessService.Interfaces.Usuarios
{
    public interface IAdministrarUsuarioBusinessService : IBusinessService
    {
        void RegistrarNuevoUsuario(RegistrarUsuarioCommand command);
    }
}
