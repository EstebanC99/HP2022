using Cross.Business.Domain.Commands;

namespace CuidadosModernos.Business.Domain.Commands.Empleadas
{
    public class RegistrarEmpleadaCommand : Command<int>
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string Mail { get; set; }

        public string Telefono { get; set; }

        public int EncargadaID { get; set; }
    }
}
