using CuidadosModernos.Domain.Usuarios.Rol;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.ResourceAccess.Repository.Config.Usuarios.Rol
{
    public class RolUsuarioConfig : EntityTypeConfiguration<RolUsuario>
    {
        public RolUsuarioConfig()
        {
            this.ToTable("t_RolUsuario");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_RolUsuario");
        }
    }
}
