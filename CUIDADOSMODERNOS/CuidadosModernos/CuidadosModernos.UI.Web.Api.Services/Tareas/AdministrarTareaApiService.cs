using Cross.CrossCutting.Mapping;
using Cross.UI.Web.Api.Services;
using CuidadosModernos.Business.Domain.Commands.Tareas;
using CuidadosModernos.Business.Domain.Queries.Tareas;
using CuidadosModernos.BusinessService.Interfaces.Tareas;
using CuidadosModernos.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuidadosModernos.UI.Web.Api.Services.Tareas
{
    public class AdministrarTareaApiService : ApiService<IAdministrarTareaBusinessService>, IAdministrarTareaApiService
    {
        public AdministrarTareaApiService(IAdministrarTareaBusinessService businessService) : base(businessService)
        {

        }

        public List<TareaResultVM> GetAll()
        {
            var tareas = this.BusinessService.GetAll();

            var mapper = new Mapper<TareaDataView, TareaResultVM>(cfg =>
            {
                cfg.CreateMap<TareaDataView, TareaResultVM>();
            });

            return mapper.Map(tareas);
        }

        public TareaDetalleVM GetByID(TareaFiltroVM filtroVM)
        {
            var tareas = this.BusinessService.GetByID(filtroVM.ID);

            var mapper = new Mapper<TareaDataView, TareaDetalleVM>(cfg =>
            {
                cfg.CreateMap<TareaDataView, TareaDetalleVM>();
            });

            return mapper.Map(tareas);
        }

        public void RegistrarTarea(TareaDetalleVM viewModel)
        {
            var mapper = new Mapper<TareaDetalleVM, RegistrarTareaCommand>(cfg =>
            {
                cfg.CreateMap<TareaDetalleVM, RegistrarTareaCommand>()
                   .ForMember(x => x.HoraRealizacion, src => src.MapFrom(y => TimeSpan.Parse(y.HoraRealizacion)))
                   .ForMember(x => x.FechaInicioVigencia, src => src.MapFrom(y => DateTime.Parse(y.FechaInicioVigencia)))
                   .ForMember(x => x.FechaFinVigencia, src => src.MapFrom(y => !string.IsNullOrEmpty(y.FechaFinVigencia) ? DateTime.Parse(y.FechaFinVigencia) : (DateTime?)null));
            });

            this.BusinessService.RegistrarTarea(mapper.Map(viewModel));
        }

        public void ModificarTarea(TareaDetalleVM viewModel)
        {
            var mapper = new Mapper<TareaDetalleVM, ModificarTareaCommand>(cfg =>
            {
                cfg.CreateMap<TareaDetalleVM, ModificarTareaCommand>()
                   .ForMember(x => x.HoraRealizacion, src => src.MapFrom(y => TimeSpan.Parse(y.HoraRealizacion)))
                   .ForMember(x => x.FechaInicioVigencia, src => src.MapFrom(y => DateTime.Parse(y.FechaInicioVigencia)))
                   .ForMember(x => x.FechaFinVigencia, src => src.MapFrom(y => !string.IsNullOrEmpty(y.FechaFinVigencia) ? DateTime.Parse(y.FechaFinVigencia) : (DateTime?)null));
            });

            this.BusinessService.ModificarTarea(mapper.Map(viewModel));
        }

        public void DesactivarTarea(TareaResultVM tareaVM)
        {
            this.BusinessService.Desactivar(tareaVM.ID);
        }
    }
}
