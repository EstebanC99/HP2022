using Cross.Business.Domain;
using System.Collections.Generic;
using System.Linq;

namespace CuidadosModernos.Domain.Usuarios
{
    public abstract class Persona : Aggregate<int>
    {
        public virtual string Nombre { get; protected set; }

        public virtual string Apellido { get; protected set; }

        public virtual string DNI { get; protected set; }

        public virtual string Telefono { get; protected set; }

        public virtual ICollection<Usuario> Usuarios { get; protected set; }

        public virtual Usuario ObtenerUsuario()
        {
            return this.Usuarios.FirstOrDefault(u => u.Activo && !u.FechaBaja.HasValue);
        }
    }
}
