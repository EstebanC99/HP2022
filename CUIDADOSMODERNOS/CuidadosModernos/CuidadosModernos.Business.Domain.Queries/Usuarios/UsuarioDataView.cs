namespace CuidadosModernos.Business.Domain.Queries.Usuarios
{
    public class UsuarioDataView : DataView
    {
        public string Username { get; set; }

        public int PersonaID { get; set; }

        public string Rol { get; set; }
    }
}
