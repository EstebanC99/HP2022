using CuidadosModernos.Domain.Turnos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuidadosModernos.ResourceAccess.Repository.Config.Turnos
{
    public class NotaConfig: EntityTypeConfiguration<Nota>
    {
        public NotaConfig()
        {
            this.ToTable("t_Nota");

            this.HasKey(m => m.ID).Property(m => m.ID).HasColumnName("ID_Nota").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(m => m.FechaHoraCreacion).IsRequired();
            this.Property(m => m.FechaHoraRealizacion).IsRequired();
            this.Property(m => m.Urgente).IsRequired();

            this.HasRequired(m => m.Empleada).WithMany().Map(m => m.MapKey("ID_Empleada"));
        }
    }
}
