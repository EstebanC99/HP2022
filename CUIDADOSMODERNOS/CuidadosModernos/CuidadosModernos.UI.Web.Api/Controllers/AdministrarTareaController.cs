using Cross.UI.Web.Api.Controllers;
using CuidadosModernos.UI.Web.Api.Services.Tareas;
using CuidadosModernos.UI.Web.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CuidadosModernos.UI.Web.Api.Controllers
{
    [Authorize]
    public class AdministrarTareaController : ApiControllerBase<IAdministrarTareaApiService>
    {
        public AdministrarTareaController(IAdministrarTareaApiService apiService) : base(apiService)
        {

        }

        [HttpPost]
        public List<TareaResultVM> GetAll()
        {
            return this.ApiService.GetAll();
        }

        [HttpPost]
        public TareaDetalleVM GetByID(TareaFiltroVM filtroVM)
        {
            return this.ApiService.GetByID(filtroVM);
        }

        [HttpPost]
        public void Registrar(TareaDetalleVM tareaDetalleVM)
        {
            this.ApiService.RegistrarTarea(tareaDetalleVM);
        }

        [HttpPost]
        public void Modificar(TareaDetalleVM tareaDetalleVM)
        {
            this.ApiService.ModificarTarea(tareaDetalleVM);
        }

        [HttpPost]
        public void Desactivar(TareaResultVM tareaVM)
        {
            this.ApiService.DesactivarTarea(tareaVM);
        }
    }
}