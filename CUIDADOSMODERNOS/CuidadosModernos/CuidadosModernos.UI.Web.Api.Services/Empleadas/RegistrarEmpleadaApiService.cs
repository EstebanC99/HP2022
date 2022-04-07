using Cross.CrossCutting.Mapping;
using Cross.UI.Web.Api.Services;
using CuidadosModernos.Business.Domain.Commands.Empleadas;
using CuidadosModernos.BusinessService.Interfaces.Empleadas;
using CuidadosModernos.UI.Web.Models;

namespace CuidadosModernos.UI.Web.Api.Services.Empleadas
{
    public class RegistrarEmpleadaApiService : ApiService<IRegistrarEmpleadaBusinessService>, IRegistrarEmpleadaApiService
    {
        public RegistrarEmpleadaApiService(IRegistrarEmpleadaBusinessService businessService) : base(businessService)
        {

        }

        public void RegistrarEmpleada(EmpleadaDetalleVM empleadaDetalleVM)
        {
            var mapperCommand = new Mapper<EmpleadaDetalleVM, RegistrarEmpleadaCommand>(cfg =>
            {
                cfg.CreateMap<EmpleadaDetalleVM, RegistrarEmpleadaCommand>();
            });

            var command = mapperCommand.Map(empleadaDetalleVM);

            this.BusinessService.RegistrarEmpleada(command);
        }
    }
}
