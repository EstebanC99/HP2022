using CuidadosModernos.Domain.Usuarios;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Generales
{
    public class EmpleadaConfig : EntityTypeConfiguration<Empleada>
    {
        public EmpleadaConfig()
        {
            this.ToTable("t_Empleada");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_Empleada").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(m => m.Nombre).IsRequired();
            this.Property(m => m.Apellido).IsRequired();
            this.Property(m => m.DNI).IsRequired();
            this.Property(m => m.Activa).IsRequired();

            this.HasRequired(m => m.Encargada).WithMany().Map(m => m.MapKey("ID_Encargada"));
        }
    }
}
