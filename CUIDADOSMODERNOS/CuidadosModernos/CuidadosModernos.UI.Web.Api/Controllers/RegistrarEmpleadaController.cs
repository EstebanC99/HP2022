using Cross.UI.Web.Api.Controllers;
using CuidadosModernos.UI.Web.Api.Services.Empleadas;
using CuidadosModernos.UI.Web.Models;
using System.Web.Http;

namespace CuidadosModernos.UI.Web.Api.Controllers
{
    public class RegistrarEmpleadaController : ApiControllerBase<IRegistrarEmpleadaApiService>
    {
        public RegistrarEmpleadaController(IRegistrarEmpleadaApiService apiService) : base(apiService)
        {

        }

        [HttpPost]
        public void Registrar(EmpleadaDetalleVM empleadaDetalleVM)
        {
            this.ApiService.RegistrarEmpleada(empleadaDetalleVM);
        }
    }
}