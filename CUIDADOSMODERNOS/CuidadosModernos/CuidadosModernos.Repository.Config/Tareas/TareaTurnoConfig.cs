using CuidadosModernos.Domain.Tareas;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.ResourceAccess.Repository.Config.Tareas
{
    public class TareaTurnoConfig : EntityTypeConfiguration<TareaTurno>
    {
        public TareaTurnoConfig()
        {
            this.ToTable("t_TareaTurno");

            this.HasKey(m => new { m.ID, m.ID_Turno });
            this.Property(m => m.ID).HasColumnName("ID_TareaTurno").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(m => m.Estado).WithMany().Map(m => m.MapKey("ID_Estado"));
            this.HasRequired(m => m.Tarea).WithMany().Map(m => m.MapKey("ID_Tarea"));
        }
    }
}
