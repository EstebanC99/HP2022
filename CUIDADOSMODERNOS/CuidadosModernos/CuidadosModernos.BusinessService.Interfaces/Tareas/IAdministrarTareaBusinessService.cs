using Cross.BusinessService.Interfaces;
using CuidadosModernos.Business.Domain.Commands.Tareas;
using CuidadosModernos.Business.Domain.Queries.Tareas;
using System.Collections.Generic;

namespace CuidadosModernos.BusinessService.Interfaces.Tareas
{
    public interface IAdministrarTareaBusinessService : IBusinessService
    {
        List<TareaDataView> GetAll();

        TareaDataView GetByID(int tareaID);

        void RegistrarTarea(RegistrarTareaCommand command);

        void ModificarTarea(ModificarTareaCommand command);

        void Desactivar(int tareaID);
    }
}
