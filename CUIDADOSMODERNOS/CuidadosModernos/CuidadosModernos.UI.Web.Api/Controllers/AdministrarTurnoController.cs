using Cross.UI.Web.Api.Controllers;
using CuidadosModernos.UI.Web.Api.Services.Turnos;
using CuidadosModernos.UI.Web.Models;
using System.Web.Http;

namespace CuidadosModernos.UI.Web.Api.Controllers
{
    [Authorize]
    public class AdministrarTurnoController : ApiControllerBase<IAdministrarTurnoApiService>
    {
        public AdministrarTurnoController(IAdministrarTurnoApiService apiService) : base(apiService)
        {

        }

        [HttpPost]
        public void Registrar(TurnoDetalleVM detalleVM)
        {
            this.ApiService.RegistrarTurno(detalleVM);
        }
    }
}