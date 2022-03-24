using CuidadosModernos.Domain.Horarios;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Horarios
{
    public class HorarioConfig : EntityTypeConfiguration<Horario>
    {
        public HorarioConfig()
        {
            this.ToTable("t_Horario");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_Horario");

            this.Property(m => m.HoraInicio).IsRequired();
            this.Property(m => m.HoraFin).IsRequired();

            this.HasMany(m => m.Tareas).WithRequired(m => m.Horario).HasForeignKey(m => m.ID_Horario).WillCascadeOnDelete();

        }
    }
}
