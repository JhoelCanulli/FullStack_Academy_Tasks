using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace API_nasa.Models
{
    public class NasaContext : DbContext
    {
        public NasaContext(DbContextOptions<NasaContext> options) : base(options) { }

        public DbSet<CorpoCeleste> Corpi { get; set; }
        public DbSet<Sistema> Sistemi { get; set; }
        public DbSet<Corpo_Sistema> Corpi_Sistemi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Corpo_Sistema>().HasKey(i => new { i.CorpoRIF, i.SistemaRIF });

            modelBuilder.Entity<Corpo_Sistema>()
                .HasOne(cs => cs.cor)
                .WithMany(c => c.ElencoCorSis)
                .HasForeignKey(os => os.CorpoRIF);

            modelBuilder.Entity<Corpo_Sistema>()
               .HasOne(cs => cs.sis)
               .WithMany(s => s.ElencoCorSis)
               .HasForeignKey(os => os.SistemaRIF);
        }
    }
}
