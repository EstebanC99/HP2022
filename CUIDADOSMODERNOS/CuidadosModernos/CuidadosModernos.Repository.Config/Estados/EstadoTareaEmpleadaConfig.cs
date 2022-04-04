using CuidadosModernos.Domain.Estados;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Estados
{
    public class EstadoTareaEmpleadaConfig : EntityTypeConfiguration<EstadoTareaEmpleada>
    {
        public EstadoTareaEmpleadaConfig()
        {
            this.ToTable("t_EstadoTareaEmpleada");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_EstadoTareaEmpleada");
        }
    }
}
