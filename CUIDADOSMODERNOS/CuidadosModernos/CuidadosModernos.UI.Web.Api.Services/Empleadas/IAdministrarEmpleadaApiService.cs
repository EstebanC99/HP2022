using Cross.UI.Web.Api.Services;
using CuidadosModernos.UI.Web.Models;
using System.Collections.Generic;

namespace CuidadosModernos.UI.Web.Api.Services.Empleadas
{
    public interface IAdministrarEmpleadaApiService : IApiService
    {
        List<EmpleadaResultVM> GetAll();

        EmpleadaDetalleVM GetByID(EmpleadaFiltroVM filtro);

        void RegistrarEmpleada(EmpleadaDetalleVM empleadaDetalleVM);

        void ModificarEmpleada(EmpleadaDetalleVM empleadaDetalleVM);

        void EliminarEmpleada(EmpleadaResultVM empleadaVM);
    }
}