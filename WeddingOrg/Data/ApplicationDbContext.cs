using Microsoft.EntityFrameworkCore;
using WeddingOrg.Models;

namespace WeddingOrg.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        internal DbSet<Wedding> Weddings { get; set; }
        internal DbSet<Bride> Brides { get; set; }
        internal DbSet<Groom> Grooms { get; set; }
        internal DbSet<Photographer> Photographers { get; set; }
        internal DbSet<Cameraman> Cameramen { get; set; }
        internal DbSet<Restaurant> Restaurants { get; set; }
    }
}
