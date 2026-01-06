using BulgarianTraditionsAndCustoms.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BulgarianTraditionsAndCustoms.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TraditionParticipant>()
                .HasKey(tp => new {tp.TraditionId, tp.ParticipantId});
            modelBuilder.Entity<TraditionParticipant>()
                .HasOne(t => t.Tradition)
                .WithMany(tp => tp.TraditionParticipants)
                .HasForeignKey(ti => ti.TraditionId);
            modelBuilder.Entity<TraditionParticipant>()
                .HasOne(p => p.Participant)
                .WithMany(tp => tp.TraditionParticipants)
                .HasForeignKey(pi => pi.ParticipantId);
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<TraditionType> TraditionTypes { get; set; }
        public DbSet<Tradition> Traditions { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<TraditionParticipant> TraditionsParticipants { get; set; }
        
    }
}
