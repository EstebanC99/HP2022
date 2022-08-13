using Cross.UI.Web.Api.Controllers;
using CuidadosModernos.CrossCutting.Global.Roles;
using CuidadosModernos.UI.Web.Api.Services.Empleadas;
using CuidadosModernos.UI.Web.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace CuidadosModernos.UI.Web.Api.Controllers
{
    [Authorize(Roles = nameof(Roles.Encargada))]
    public class AdministrarEmpleadaController : ApiControllerBase<IAdministrarEmpleadaApiService>
    {
        public AdministrarEmpleadaController(IAdministrarEmpleadaApiService apiService) : base(apiService)
        {

        }

        [HttpPost]
        public List<EmpleadaResultVM> GetAll()
        {
            return this.ApiService.GetAll();
        }

        [HttpPost]
        public EmpleadaDetalleVM GetByID(EmpleadaFiltroVM filtro)
        {
            return this.ApiService.GetByID(filtro);
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
        public void Eliminar(EmpleadaResultVM empleadaVM)
        {
            this.ApiService.EliminarEmpleada(empleadaVM);
        }

    }
}