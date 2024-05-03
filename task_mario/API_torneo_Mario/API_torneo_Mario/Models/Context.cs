using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace API_torneo_Mario.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Squadra> Squadre { get; set; }
        public DbSet<Personaggio> Personaggi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Squadra>()
                .HasKey(s => new { s.SquadraID });

            modelBuilder.Entity<Personaggio>()
                .HasKey(p => new { p.PersonaggioID });

            modelBuilder.Entity<Squadra>()
                .HasMany(e => e.Personaggi)
                .WithOne(e => e.Squadra)
                .HasForeignKey(e => e.SquadraRIF);
        }
    }
}
