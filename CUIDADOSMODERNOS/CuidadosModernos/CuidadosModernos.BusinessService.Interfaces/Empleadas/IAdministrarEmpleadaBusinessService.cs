using Cross.BusinessService.Interfaces;
using CuidadosModernos.Business.Domain.Commands.Empleadas;

namespace CuidadosModernos.BusinessService.Interfaces.Empleadas
{
    public interface IAdministrarEmpleadaBusinessService : IBusinessService
    {
        void RegistrarEmpleada(RegistrarEmpleadaCommand command);

        void ModificarEmpleada(ModificarEmpleadaCommand command);

        void EliminarEmpleada(int empleadaID);
    }
}
