using CuidadosModernos.Domain.Tareas;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Tareas
{
    public class TareaHorarioConfig : EntityTypeConfiguration<TareaHorario>
    {
        public TareaHorarioConfig()
        {
            this.ToTable("t_TareaHorario");

            this.HasKey(m => new { m.ID, m.ID_Horario });
            this.Property(m => m.ID).HasColumnName("ID_Horario").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(m => m.Tarea).WithMany().Map(m => m.MapKey("ID_Tarea"));
        }
    }
}
