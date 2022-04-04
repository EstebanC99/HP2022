using CuidadosModernos.Domain.Tareas;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Tareas
{
    public class TareaConfig : EntityTypeConfiguration<Tarea>
    {
        public TareaConfig()
        {
            this.ToTable("t_Tarea");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_Tarea");

            this.Property(m => m.HoraMinima).IsRequired();

            this.Property(m => m.HoraMaxima).IsOptional();
        }
    }
}
