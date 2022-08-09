using Cross.BusinessService.Interfaces;
using CuidadosModernos.Business.Domain.Commands.Turnos;

namespace CuidadosModernos.BusinessService.Interfaces.Turnos
{
    public interface IAdministrarTurnoBusinessService : IBusinessService
    {
        void RegistrarTurno(RegistrarTurnoCommand command);
    }
}
