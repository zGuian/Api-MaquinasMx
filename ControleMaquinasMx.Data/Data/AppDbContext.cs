using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ControleMaquinasMx.Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Maquinas>? Maquinas { get; set; }
        public DbSet<Pacotes>? Pacotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MaquinasConfiguration());
            modelBuilder.ApplyConfiguration(new PacotesConfiguration());
        }
    }
}
