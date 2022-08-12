using CuidadosModernos.Domain.Usuarios;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.ResourceAccess.Repository.Config.Usuarios
{
    public class PersonaConfig : EntityTypeConfiguration<Persona>
    {
        public PersonaConfig()
        {
            this.ToTable("t_Persona");

            this.HasKey(p => p.ID).Property(p => p.ID).HasColumnName("ID_Persona").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(m => m.Nombre).IsRequired();
            this.Property(m => m.Apellido).IsRequired();
            this.Property(m => m.DNI).IsRequired();

            this.HasMany(m => m.Usuarios).WithRequired(p => p.Persona).HasForeignKey(p => p.ID_Persona).WillCascadeOnDelete();
        }
    }
}
