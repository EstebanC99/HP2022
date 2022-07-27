using Cross.CrossCutting.Mapping;
using Cross.UI.Web.Api.Services;
using CuidadosModernos.Business.Domain.Commands.Empleadas;
using CuidadosModernos.Business.Domain.Queries.Empleadas;
using CuidadosModernos.BusinessService.Interfaces.Empleadas;
using CuidadosModernos.UI.Web.Models;
using System.Collections.Generic;

namespace CuidadosModernos.UI.Web.Api.Services.Empleadas
{
    public class AdministrarEmpleadaApiService : ApiService<IAdministrarEmpleadaBusinessService>, IAdministrarEmpleadaApiService
    {
        public AdministrarEmpleadaApiService(IAdministrarEmpleadaBusinessService businessService) : base(businessService)
        {

        }

        public List<EmpleadaResultVM> GetAll()
        {
            var empleadas = this.BusinessService.GetAll();

            var mapper = new Mapper<EmpleadaDataView, EmpleadaResultVM>(cfg =>
            {
                cfg.CreateMap<EmpleadaDataView, EmpleadaResultVM>()
                .ForMember(x => x.NombreCompleto, src => src.MapFrom(x => string.Join(" ", x.Nombre, x.Apellido)));
            });

            return mapper.Map(empleadas);
        }

        public EmpleadaDetalleVM GetByID(EmpleadaFiltroVM filtro)
        {
            var empleada = this.BusinessService.GetByID(filtro.ID);

            var mapper = new Mapper<EmpleadaDataView, EmpleadaDetalleVM>(cfg =>
            {
                cfg.CreateMap<EmpleadaDataView, EmpleadaDetalleVM>();
            });

            return mapper.Map(empleada);
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

        public void EliminarEmpleada(EmpleadaResultVM empleadaVM)
        {
            this.BusinessService.EliminarEmpleada(empleadaVM.ID);
        }
    }
}
