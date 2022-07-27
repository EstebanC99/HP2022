using CuidadosModernos.Domain.Tareas;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Tareas
{
    public class TareaConfig : EntityTypeConfiguration<Tarea>
    {
        public TareaConfig()
        {
            this.ToTable("t_Tarea");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_Tarea").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            this.Property(m => m.Titulo).IsRequired();
            this.Property(m => m.Descripcion).IsRequired();
            this.Property(m => m.HoraRealizacion).IsRequired();
            this.Property(m => m.FechaInicioVigencia).IsRequired();
            this.Property(m => m.Activa).IsRequired();

            this.HasRequired(m => m.Frecuencia).WithMany().Map(m => m.MapKey("ID_Frecuencia"));
        }
    }
}
