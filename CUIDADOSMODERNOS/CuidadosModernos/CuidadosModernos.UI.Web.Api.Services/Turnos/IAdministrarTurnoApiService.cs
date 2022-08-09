using Cross.UI.Web.Api.Services;
using CuidadosModernos.UI.Web.Models;

namespace CuidadosModernos.UI.Web.Api.Services.Turnos
{
    public interface IAdministrarTurnoApiService : IApiService
    {
        void RegistrarTurno(TurnoDetalleVM turnoDetalleVM);
    }
}