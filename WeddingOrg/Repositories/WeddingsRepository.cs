using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Threading;
using WeddingOrg.Data;
using WeddingOrg.DTOs;
using WeddingOrg.Exceptions;
using WeddingOrg.Models;
using WeddingOrg.Views;
 
namespace WeddingOrg.Repositories
{
    public class WeddingsRepository : IWeddingsRepository
    {
        public readonly ApplicationDbContext _dbContext;
        
        public WeddingsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Wedding>> GetWeddings(CancellationToken cancellationToken)
        {
            var wedding = await _dbContext.Weddings
                .Include(x => x.Bride)
                .Include(x => x.Groom)   
                .ToListAsync(cancellationToken);           
            var cameraman = await _dbContext.Cameramen.ToListAsync(cancellationToken);
            var restaurant = await _dbContext.Restaurants.ToListAsync(cancellationToken);
            return wedding;
        }
        public async Task<IEnumerable<Photographer>> GetPhotographers(CancellationToken cancellationToken)
        {
            var photographer = await _dbContext.Photographers
                .ToListAsync(cancellationToken);
            return photographer;
        }
        public async Task<IEnumerable<Cameraman>> GetCameramen(CancellationToken cancellationToken)
        {
            var cameraman = await _dbContext.Cameramen
                .ToListAsync(cancellationToken);
            return cameraman;
        }
        public async Task<IEnumerable<Restaurant>> GetRestaurants(CancellationToken cancellationToken)
        {
            var restaurant = await _dbContext.Restaurants
                .ToListAsync(cancellationToken);
            return restaurant;
        }
        public async Task<Wedding> GetWeddingById(int id, CancellationToken cancellationToken)
        {
            var wedding = await _dbContext.Weddings.SingleOrDefaultAsync(w => w.Id == id);
            if (wedding == default)
            {
                throw new WeddingNotFoundException($"Wedding with {id} does not exist.");
            }
            return wedding;
        }
        public async Task<Bride> GetBrideById(int id, CancellationToken cancellationToken)
        {
            var bride = await _dbContext.Brides.SingleOrDefaultAsync(w => w.Id == id);
            if (bride == default)
            {
                throw new WeddingNotFoundException($"Wedding with {id} does not exist.");
            }
            return bride;
        }
        public async Task<Groom> GetGroomById(int id, CancellationToken cancellationToken)
        {
            var groom = await _dbContext.Grooms.SingleOrDefaultAsync(w => w.Id == id);
            if (groom == default)
            {
                throw new WeddingNotFoundException($"Wedding with {id} does not exist.");
            }
            return groom;
        }
        public async Task<Photographer> GetPhotographerById(int id, CancellationToken cancellationToken)
        {
            var photographer = await _dbContext.Photographers.SingleOrDefaultAsync(p => p.Id == id);
            if (photographer == default)
            {
                throw new WeddingNotFoundException($"Photographer with {id} does not exist.");
            }
            return photographer;
        }
        public async Task<Cameraman> GetCameramanById(int id, CancellationToken cancellationToken)
        {
            var cameraman = await _dbContext.Cameramen.SingleOrDefaultAsync(p => p.Id == id);
            if (cameraman == default)
            {
                throw new WeddingNotFoundException($"Cameraman with {id} does not exist.");
            }
            return cameraman;
        }
        public async Task<Restaurant> GetRestaurantById(int id, CancellationToken cancellationToken)
        {
            var restaurant = await _dbContext.Restaurants.SingleOrDefaultAsync(p => p.Id == id);
            if (restaurant == default)
            {
                throw new WeddingNotFoundException($"Cameraman with {id} does not exist.");
            }
            return restaurant;
        }
        public async Task<int> CreateWeedingBrideGroom(UpdateWeddingBrideGroomDto dto)
        {
            Bride bride = new Bride()
            {
                Name = dto.brideName,
                PhoneNumber = dto.bridePhoneNumber,
                Email = dto.brideEmail,
                Instagram = dto.brideInstagram
            };
            Groom groom = new Groom()
            {
                Name = dto.groomName,
                PhoneNumber = dto.groomPhoneNumber,
                Email = dto.groomEmail,
                Instagram = dto.groomInstagram
            };
            Wedding wedding = new Wedding()
            {
                DateOfSigningTheContract = dto.dateOfSigningTheContract,
                DateOfTheWedding = dto.dateOfTheWedding,
                Bride = bride,
                Groom = groom,
            };
            await _dbContext.Weddings.AddAsync(wedding);
            await _dbContext.SaveChangesAsync();
            return wedding.Id;          
        }        
        public async Task<int> CreatePhotographer(UpdatePhotographerDto dto)
        {
            Photographer photographer = new()
            {
                Facebook = dto.photographerFacebook,
                Instagram = dto.photographerInstagram,
            };
            await _dbContext.AddAsync(photographer);
            await _dbContext.SaveChangesAsync();
            return photographer.Id; 
        }
        public async Task<int> CreateCameraman(UpdateCameramanDto dto)
        {
            Cameraman cameraman = new()
            {
                Facebook = dto.cameramanFacebook,
                Instagram = dto.cameramanInstagram,
            };
            await _dbContext.AddAsync(cameraman);
            await _dbContext.SaveChangesAsync();
            return cameraman.Id;
        }
        public async Task<int> CreateRestaurant(UpdateRestaurantDto dto)
        {
            Restaurant restaurant = new()
            {
                Facebook = dto.restaurantFacebook,
                Instagram = dto.restaurantInstagram,
            };
            await _dbContext.AddAsync(restaurant);
            await _dbContext.SaveChangesAsync();
            return restaurant.Id;
        }
        
        public async Task<int> ChangeWedding(int weddingId, UpdateWeddingDto dto, CancellationToken cancellationToken)
        {
            var wedding = await _dbContext.Weddings.SingleOrDefaultAsync(w => w.Id == weddingId, cancellationToken);
            wedding.DateOfSigningTheContract = dto.dateOfSigningTheContract;
            wedding.DateOfTheWedding = dto.dateOfTheWedding;
            await _dbContext.SaveChangesAsync();
            return wedding.Id;
        }
        public async Task<int> ChangeBride(int brideId, UpdateBrideDto dto, CancellationToken cancellationToken)
        {
            var bride = await _dbContext.Brides.SingleOrDefaultAsync(w => w.Id == brideId, cancellationToken);            
            bride.Name = dto.brideName;
            bride.PhoneNumber = dto.bridePhoneNumber;
            bride.Email = dto.brideEmail;
            bride.Instagram = dto.brideInstagram;
            await _dbContext.SaveChangesAsync();
            return bride.Id;
        }
        public async Task<int> ChangeGroom(int groomId, UpdateGroomDto dto, CancellationToken cancellationToken)
        {
            var groom = await _dbContext.Grooms.SingleOrDefaultAsync(w => w.Id == groomId, cancellationToken);
            groom.Name = dto.groomName;
            groom.PhoneNumber = dto.groomPhoneNumber;
            groom.Email = dto.groomEmail;
            groom.Instagram = dto.groomInstagram;
            await _dbContext.SaveChangesAsync();
            return groom.Id;
        }
        public async Task<int> ChangePhotographer(int photographerId, UpdatePhotographerDto dto, CancellationToken cancellationToken)
        {
            var photographer = await _dbContext.Photographers.SingleOrDefaultAsync(w => w.Id == photographerId, cancellationToken);
            photographer.Facebook = dto.photographerFacebook;
            photographer.Instagram = dto.photographerInstagram;
            await _dbContext.SaveChangesAsync();
            return photographer.Id;
        }
        public async Task<int> ChangeCameraman(int cameramanId, UpdateCameramanDto dto, CancellationToken cancellationToken)
        {
            var cameraman = await _dbContext.Cameramen.SingleOrDefaultAsync(w => w.Id == cameramanId, cancellationToken);
            cameraman.Facebook = dto.cameramanFacebook;
            cameraman.Instagram = dto.cameramanInstagram;
            await _dbContext.SaveChangesAsync();
            return cameraman.Id;
        }
        public async Task<int> ChangeRestaurant(int restaurantId, UpdateRestaurantDto dto, CancellationToken cancellationToken)
        {
            var restaurant = await _dbContext.Restaurants.SingleOrDefaultAsync(w => w.Id == restaurantId, cancellationToken);
            restaurant.Facebook = dto.restaurantFacebook;
            restaurant.Instagram = dto.restaurantInstagram;
            await _dbContext.SaveChangesAsync();
            return restaurant.Id;
        }
        public async Task<int> DeleteWeddingById(int id, CancellationToken cancellationToken)
        {
            var weddingDeletion = await _dbContext.Weddings.SingleOrDefaultAsync(w => w.Id == id, cancellationToken);
            _dbContext.Weddings.Remove(weddingDeletion);
            await _dbContext.SaveChangesAsync();
            return weddingDeletion.Id;
        }
        public async Task<int> DeleteBrideById(int id, CancellationToken cancellationToken)
        {
            var brideDeletion = await _dbContext.Brides.SingleOrDefaultAsync(w => w.Id == id, cancellationToken);
            _dbContext.Brides.Remove(brideDeletion);
            await _dbContext.SaveChangesAsync();
            return brideDeletion.Id;
        }
        public async Task<int> DeleteGroomById(int id, CancellationToken cancellationToken)
        {
            var groomDeletion = await _dbContext.Grooms.SingleOrDefaultAsync(w => w.Id == id, cancellationToken);
            _dbContext.Grooms.Remove(groomDeletion);
            await _dbContext.SaveChangesAsync();
            return groomDeletion.Id;
        }
        public async Task<int> DeletePhotographerById(int id, CancellationToken cancellationToken)
        {
            var photographerDeletion = await _dbContext.Photographers.SingleOrDefaultAsync(w => w.Id == id, cancellationToken);
            _dbContext.Photographers.Remove(photographerDeletion);
            await _dbContext.SaveChangesAsync();
            return photographerDeletion.Id;
        }
        public async Task<int> DeleteCameramanById(int id, CancellationToken cancellationToken)
        {
            var cameramanDeletion = await _dbContext.Cameramen.SingleOrDefaultAsync(w => w.Id == id, cancellationToken);
            _dbContext.Cameramen.Remove(cameramanDeletion);
            await _dbContext.SaveChangesAsync();
            return cameramanDeletion.Id;
        }
        public async Task<int> DeleteRestaurantById(int id, CancellationToken cancellationToken)
        {
            var restaurantDeletion = await _dbContext.Restaurants.SingleOrDefaultAsync(w => w.Id == id, cancellationToken);
            _dbContext.Restaurants.Remove(restaurantDeletion);
            await _dbContext.SaveChangesAsync();
            return restaurantDeletion.Id;
        }
        public async Task<Wedding> AddPhotographerToWedding(int weddingId, int photographerId)
        {
            var photographer = await _dbContext.Photographers.SingleOrDefaultAsync(p => p.Id == photographerId);
            var wedding = await _dbContext.Weddings.SingleOrDefaultAsync(p => p.Id == weddingId);
            wedding.Photographer = photographer;
            await _dbContext.SaveChangesAsync();
            return wedding;
        }
        public async Task<Wedding> AddCameramanToWedding(int weddingId, int cameramanId)
        {
            var cameraman = await _dbContext.Cameramen.SingleOrDefaultAsync(p => p.Id == cameramanId);
            var wedding = await _dbContext.Weddings.SingleOrDefaultAsync(p => p.Id == weddingId);
            wedding.Cameraman = cameraman;
            await _dbContext.SaveChangesAsync();
            return wedding;
        }
        public async Task<Wedding> AddRestaurantToWedding(int weddingId, int restaurantId)
        {
            var restaurant = await _dbContext.Restaurants.SingleOrDefaultAsync(p => p.Id == restaurantId);
            var wedding = await _dbContext.Weddings.SingleOrDefaultAsync(p => p.Id == weddingId);
            wedding.Restaurant = restaurant;
            await _dbContext.SaveChangesAsync();
            return wedding;
        }
    }
}
