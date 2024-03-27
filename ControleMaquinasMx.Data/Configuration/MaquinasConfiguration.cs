using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_Domain.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMaquinasMx_Data.Configuration
{
    internal class MaquinasConfiguration : IEntityTypeConfiguration<Maquina>
    {
        public void Configure(EntityTypeBuilder<Maquina> builder)
        {
            builder.Property(x => x.Criticidade).HasConversion(
                x => x.ToString(),
                x => (Criticidade)Enum.Parse(typeof(Criticidade), x));
        }
    }
}
