using ControleMaquinasMx_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleMaquinasMx_Data.Configuration
{
    internal class PacotesConfiguration : IEntityTypeConfiguration<Pacotes>
    {
        public void Configure(EntityTypeBuilder<Pacotes> builder)
        {
            builder.HasOne(x => x.Maquinas)
                   .WithMany(x => x.Pacotes)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
