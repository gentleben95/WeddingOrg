using Microsoft.EntityFrameworkCore;
using WeddingOrg.Domain.Entities;

namespace WeddingOrg.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Bride> Brides { get; set; }
        public DbSet<Groom> Grooms { get; set; }
        public DbSet<Photographer> Photographers { get; set; }
        public DbSet<Cameraman> Cameramen { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
