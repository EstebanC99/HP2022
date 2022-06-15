using Cross.UI.Web.Api.Services;
using CuidadosModernos.UI.Web.Models;

namespace CuidadosModernos.UI.Web.Api.Services.Empleadas
{
    public interface IAdministrarEmpleadaApiService : IApiService
    {
        void RegistrarEmpleada(EmpleadaDetalleVM empleadaDetalleVM);

        void ModificarEmpleada(EmpleadaDetalleVM empleadaDetalleVM);

        void EliminarEmpleada(EmpleadaDetalleVM empleadaDetalleVM);
    }
}