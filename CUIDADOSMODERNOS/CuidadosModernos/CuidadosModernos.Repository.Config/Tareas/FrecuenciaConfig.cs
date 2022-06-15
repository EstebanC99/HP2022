using CuidadosModernos.Domain.Tareas;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Tareas
{
    public class FrecuenciaConfig : EntityTypeConfiguration<Frecuencia>
    {
        public FrecuenciaConfig()
        {
            this.ToTable("t_Frecuencia");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_Frecuencia");
        }
    }
}
