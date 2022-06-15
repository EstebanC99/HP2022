using CuidadosModernos.Domain.Horarios;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CuidadosModernos.Repository.Config.Horarios
{
    public class TurnoConfig : EntityTypeConfiguration<Turno>
    {
        public TurnoConfig()
        {
            this.ToTable("t_Turno");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_Turno").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); ;

            this.Property(m => m.FechaHoraInicio).IsRequired();
            this.Property(m => m.FechaHoraFin).IsRequired();
            this.Property(m => m.FechaHoraRealInicio).IsRequired();
            this.Property(m => m.FechaHoraRealFin).IsRequired();

            this.HasRequired(m => m.Empleada).WithMany().Map(m => m.MapKey("ID_Empleada"));
            this.HasOptional(m => m.Empleada).WithMany().Map(m => m.MapKey("ID_Empleada"));

            this.HasMany(m => m.Tareas).WithRequired(m => m.Turno).HasForeignKey(m => m.ID_Turno).WillCascadeOnDelete();
        }
    }
}
