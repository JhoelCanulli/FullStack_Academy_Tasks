using Microsoft.EntityFrameworkCore;

namespace ASP_WEB_impiegati.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
    
        public DbSet<Impiegato> Impiegati { get; set; }
        public DbSet<Residenza> Residenze { get; set;}
        public DbSet<Reparto> Reparti { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Impiegato>()
                .HasKey(i => new { i.ImpiegatoID });
            
            modelBuilder.Entity<Residenza>()
                .HasKey(res => new { res.ResidenzaID });

            modelBuilder.Entity<Reparto>()
                .HasKey(rep => new { rep.RepartoID });

            modelBuilder.Entity<Residenza>()
                .HasMany(i => i.Impiegati)
                .WithOne(res => res.Residenza)
                .HasForeignKey(res => res.ResidenzaRIF);

            modelBuilder.Entity<Reparto>()
                .HasMany(i => i.Impiegati)
                .WithOne(rep => rep.Reparto)
                .HasForeignKey(rep => rep.RepartoRIF);
        }
    }
}
