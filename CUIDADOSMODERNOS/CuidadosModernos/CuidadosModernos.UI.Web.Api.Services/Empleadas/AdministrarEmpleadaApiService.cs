using Cross.CrossCutting.Mapping;
using Cross.UI.Web.Api.Services;
using CuidadosModernos.Business.Domain.Commands.Empleadas;
using CuidadosModernos.BusinessService.Interfaces.Empleadas;
using CuidadosModernos.UI.Web.Models;

namespace CuidadosModernos.UI.Web.Api.Services.Empleadas
{
    public class AdministrarEmpleadaApiService : ApiService<IAdministrarEmpleadaBusinessService>, IAdministrarEmpleadaApiService
    {
        public AdministrarEmpleadaApiService(IAdministrarEmpleadaBusinessService businessService) : base(businessService)
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

        public void ModificarEmpleada(EmpleadaDetalleVM empleadaDetalleVM)
        {
            var mapperCommand = new Mapper<EmpleadaDetalleVM, ModificarEmpleadaCommand>(cfg =>
            {
                cfg.CreateMap<EmpleadaDetalleVM, ModificarEmpleadaCommand>();
            });

            var command = mapperCommand.Map(empleadaDetalleVM);

            this.BusinessService.ModificarEmpleada(command);
        }

        public void EliminarEmpleada(EmpleadaDetalleVM empleadaDetalleVM)
        {
            this.BusinessService.EliminarEmpleada(empleadaDetalleVM.ID);
        }
    }
}
