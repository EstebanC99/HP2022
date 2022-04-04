using CuidadosModernos.Domain.Tareas;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Tareas
{
    public class TareaEmpleadaConfig : EntityTypeConfiguration<TareaEmpleada>
    {
        public TareaEmpleadaConfig()
        {
            this.ToTable("t_TareaEmpleada");
            this.HasKey(m => new { m.ID, m.ID_Empleada });
            this.Property(m => m.ID).HasColumnName("ID_TareaEmpleada").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(m => m.Tarea).WithMany().Map(m => m.MapKey("ID_Tarea"));
            this.HasRequired(m => m.Estado).WithMany().Map(m => m.MapKey("ID_EstadoTareaEmpleada"));

        }
    }
}
