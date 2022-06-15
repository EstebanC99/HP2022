using CuidadosModernos.Domain.Turnos;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.ResourceAccess.Repository.Config.Turnos
{
    public class EstadoTareaTurnoConfig : EntityTypeConfiguration<EstadoTareaTurno>
    {
        public EstadoTareaTurnoConfig()
        {
            this.ToTable("t_EstadoTareaTurno");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_EstadoTareaTurno");
        }
    }
}
