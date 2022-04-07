using Cross.UI.Web.Api.Services;
using CuidadosModernos.UI.Web.Models;

namespace CuidadosModernos.UI.Web.Api.Services.Empleadas
{
    public interface IRegistrarEmpleadaApiService : IApiService
    {
        void RegistrarEmpleada(EmpleadaDetalleVM empleadaDetalleVM);
    }
}