using Microsoft.EntityFrameworkCore;
using WeddingOrg.Domain.Entities;

namespace WeddingOrg.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Bride> Brides { get; set; }
        DbSet<Cameraman> Cameramen { get; set; }
        DbSet<Groom> Grooms { get; set; }
        DbSet<Photographer> Photographers { get; set; }
        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<Wedding> Weddings { get; set; }
    }
}