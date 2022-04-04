using CuidadosModernos.Domain.Generales;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Generales
{
    public class EmpleadaConfig : EntityTypeConfiguration<Empleada>
    {
        public EmpleadaConfig()
        {
            this.ToTable("t_Empleada");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_Empleada");

            this.Property(m => m.Nombre).IsRequired();
            this.Property(m => m.Apellido).IsRequired();
            this.Property(m => m.DNI).IsRequired();

            this.HasMany(m => m.Tareas).WithRequired(m => m.Empleada).HasForeignKey(m => m.ID_Empleada).WillCascadeOnDelete();

            this.HasRequired(m => m.Encargada).WithMany().Map(m => m.MapKey("ID_Encargada"));
        }
    }
}
