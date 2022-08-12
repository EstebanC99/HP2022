using CuidadosModernos.Domain.Usuarios;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.ResourceAccess.Repository.Config.Usuarios
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            this.ToTable("t_Usuario");

            this.HasKey(m => new { m.ID, m.ID_Persona });

            this.Property(m => m.ID).HasColumnName("ID_Usuario").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(m => m.Username).IsRequired();
            this.Property(m => m.Password).IsRequired();
            this.Property(m => m.FechaAlta).IsRequired();
            this.Property(m => m.FechaBaja).IsOptional();
        }
    }
}
