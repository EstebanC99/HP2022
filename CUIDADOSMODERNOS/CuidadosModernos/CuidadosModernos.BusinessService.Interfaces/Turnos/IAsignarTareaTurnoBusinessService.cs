using Cross.BusinessService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuidadosModernos.BusinessService.Interfaces.Turnos
{
    public interface IAsignarTareaTurnoBusinessService : IBusinessService
    {
        void Asignar();
    }
}
