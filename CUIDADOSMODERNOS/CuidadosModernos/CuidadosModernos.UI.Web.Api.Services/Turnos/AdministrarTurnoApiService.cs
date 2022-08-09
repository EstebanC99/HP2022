using Cross.CrossCutting.Mapping;
using Cross.UI.Web.Api.Services;
using CuidadosModernos.Business.Domain.Commands.Turnos;
using CuidadosModernos.BusinessService.Interfaces.Turnos;
using CuidadosModernos.UI.Web.Models;

namespace CuidadosModernos.UI.Web.Api.Services.Turnos
{
    public class AdministrarTurnoApiService : ApiService<IAdministrarTurnoBusinessService>, IAdministrarTurnoApiService
    {
        public AdministrarTurnoApiService(IAdministrarTurnoBusinessService businessService) : base(businessService)
        {

        }

        public void RegistrarTurno(TurnoDetalleVM turnoDetalleVM)
        {
            var mapper = new Mapper<TurnoDetalleVM, RegistrarTurnoCommand>(cfg =>
            {
                cfg.CreateMap<TurnoDetalleVM, RegistrarTurnoCommand>();
            });

            this.BusinessService.RegistrarTurno(mapper.Map(turnoDetalleVM));
        }
    }
}
