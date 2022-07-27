namespace CuidadosModernos.Business.Domain.Queries.Empleadas
{
    public class EmpleadaDataView : DataView
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public virtual string DNI { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public int EncargadaID { get; set; }

        public string EncargadaNombreApellido { get; set; }
    }
}
