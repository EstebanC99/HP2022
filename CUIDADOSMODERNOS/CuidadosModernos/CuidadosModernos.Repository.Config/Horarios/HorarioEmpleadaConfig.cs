using CuidadosModernos.Domain.Horarios;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Horarios
{
    public class HorarioEmpleadaConfig : EntityTypeConfiguration<HorarioEmpleada>
    {
        public HorarioEmpleadaConfig()
        {
            this.ToTable("t_EmpleadaHorario");

            this.HasKey(m => new { m.ID, m.ID_Empleada });
            this.Property(m => m.ID).HasColumnName("ID_EmpleadaHorario").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(m => m.Horario).WithMany().Map(m => m.MapKey("ID_Horario"));

            this.Property(m => m.FechaVigencia).IsRequired();
        }
    }
}
