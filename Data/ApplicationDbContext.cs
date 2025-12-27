using BulgarianTraditionsAndCustoms.Models;
using Microsoft.EntityFrameworkCore;

namespace BulgarianTraditionsAndCustoms.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<TraditionType> TraditionTypes { get; set; }
    }
}
