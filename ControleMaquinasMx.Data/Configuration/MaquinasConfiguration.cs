using Microsoft.EntityFrameworkCore;
using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_Core.Models.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMaquinasMx_Data.Configuration
{
    internal class MaquinasConfiguration : IEntityTypeConfiguration<Maquinas>
    {
        public void Configure(EntityTypeBuilder<Maquinas> builder)
        {
            builder.Property(x => x.Criticidade).HasConversion(
                x => x.ToString(), 
                x => (Criticidade)Enum.Parse(typeof(Criticidade), x));
        }
    }
}
