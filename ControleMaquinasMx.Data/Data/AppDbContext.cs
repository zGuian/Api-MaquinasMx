using Microsoft.EntityFrameworkCore;
using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_Data.Configuration;

namespace ControleMaquinasMx.Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MaquinasConfiguration());
            modelBuilder.ApplyConfiguration(new PacotesConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
