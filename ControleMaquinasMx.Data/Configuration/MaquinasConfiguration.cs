using ControleMaquinasMx.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMaquinasMx_Data.Configuration
{
    internal class MaquinasConfiguration : IEntityTypeConfiguration<Maquinas>
    {
        public void Configure(EntityTypeBuilder<Maquinas> builder)
        {
            
        }
    }
}
