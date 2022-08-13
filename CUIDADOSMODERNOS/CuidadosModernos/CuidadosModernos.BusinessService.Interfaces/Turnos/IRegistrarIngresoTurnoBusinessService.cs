using Cross.BusinessService.Interfaces;
using CuidadosModernos.Business.Domain.Commands.Turnos;

namespace CuidadosModernos.BusinessService.Interfaces.Turnos
{
    public interface IRegistrarIngresoTurnoBusinessService : IBusinessService
    {
        void RegistrarIngreso(RegistrarIngresoTurnoCommand command);

        void FinalizarTurnoAnterior(RegistrarIngresoTurnoCommand command);
    }
}
