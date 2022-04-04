using CuidadosModernos.Domain.Encargadas;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Usuarios
{
    public class EncargadaConfig : EntityTypeConfiguration<Encargada>
    {
        public EncargadaConfig()
        {
            this.ToTable("t_Encargada");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_Encargada");

            this.Property(m => m.Nombre).IsRequired();
            this.Property(m => m.Apellido).IsRequired();
            this.Property(m => m.DNI).IsRequired();

        }
    }
}
