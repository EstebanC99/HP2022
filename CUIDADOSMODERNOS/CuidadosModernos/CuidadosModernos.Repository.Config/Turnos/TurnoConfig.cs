using CuidadosModernos.Domain.Horarios;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Horarios
{
    public class TurnoConfig : EntityTypeConfiguration<Turno>
    {
        public TurnoConfig()
        {
            this.ToTable("t_Turno");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_Turno");

            this.Property(m => m.FechaHoraInicio).IsRequired();
            this.Property(m => m.FechaHoraFin).IsRequired();

            this.HasRequired(m => m.Empleada).WithMany().Map(m => m.MapKey("ID_Empleada"));

        }
    }
}
