using Cross.BusinessService.Interfaces;
using CuidadosModernos.Business.Domain.Commands.Empleadas;
using CuidadosModernos.Business.Domain.Queries.Empleadas;
using System.Collections.Generic;

namespace CuidadosModernos.BusinessService.Interfaces.Empleadas
{
    public interface IAdministrarEmpleadaBusinessService : IBusinessService
    {
        List<EmpleadaDataView> GetAll();

        EmpleadaDataView GetByID(int empleadaID);

        void RegistrarEmpleada(RegistrarEmpleadaCommand command);

        void ModificarEmpleada(ModificarEmpleadaCommand command);

        void EliminarEmpleada(int empleadaID);
    }
}
