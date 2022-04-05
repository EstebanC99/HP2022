using Cross.BusinessService.Interfaces;
using CuidadosModernos.Business.Domain.Commands.Empleadas;

namespace CuidadosModernos.BusinessService.Interfaces.Empleadas
{
    public interface IRegistrarEmpleadaBusinessService : IBusinessService
    {
        void RegistrarEmpleada(RegistrarEmpleadaCommand command);
    }
}
