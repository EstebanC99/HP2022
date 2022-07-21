using Cross.UI.Web.Api.Controllers;
using CuidadosModernos.UI.Web.Api.Services.Empleadas;
using CuidadosModernos.UI.Web.Models;
using System.Web;
using System.Web.Http;

namespace CuidadosModernos.UI.Web.Api.Controllers
{
    [Authorize]
    public class AdministrarEmpleadaController : ApiControllerBase<IAdministrarEmpleadaApiService>
    {
        public AdministrarEmpleadaController(IAdministrarEmpleadaApiService apiService) : base(apiService)
        {

        }

        [HttpPost]
        public void Registrar(EmpleadaDetalleVM empleadaDetalleVM)
        {
            this.ApiService.RegistrarEmpleada(empleadaDetalleVM);
        }

        [HttpPost]
        public void Modificar(EmpleadaDetalleVM empleadaDetalleVM)
        {
            var user = HttpContext.Current.User;
            this.ApiService.ModificarEmpleada(empleadaDetalleVM);
        }

        [HttpPost]
        public void Eliminar(EmpleadaDetalleVM empleadaDetalleVM)
        {
            this.ApiService.EliminarEmpleada(empleadaDetalleVM);
        }

    }
}