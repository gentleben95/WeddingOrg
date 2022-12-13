using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingOrg.DTOs;
using WeddingOrg.Models;
using WeddingOrg.Views;

namespace WeddingOrg.Repositories
{
    public interface IWeddingsRepository
    {
        // Get        
        Task<IEnumerable<Wedding>> GetWeddingsBridesGrooms(CancellationToken cancellationToken);        
        Task<IEnumerable<Photographer>> GetPhotographers(CancellationToken cancellationToken);
        Task<IEnumerable<Cameraman>> GetCameramen(CancellationToken cancellationToken);
        Task<IEnumerable<Restaurant>> GetRestaurants(CancellationToken cancellationToken);

        //GetById
        Task<FullWeedingView> GetWeddingById(int id, CancellationToken cancellationToken);
        Task<Bride> GetBrideById(int id, CancellationToken cancellationToken);
        Task<Groom> GetGroomById(int id, CancellationToken cancellationToken);
        Task<Photographer> GetPhotographerById(int id, CancellationToken cancellationToken);
        Task<Cameraman> GetCameramanById(int id, CancellationToken cancellationToken);
        Task<Restaurant> GetRestaurantById(int id, CancellationToken cancellationToken);

        //Create 
        Task<int> CreateWeedingBrideGroom(UpdateWeddingBrideGroomDto dto, CancellationToken cancellationToken);
        Task<int> CreatePhotograph(UpdatePhotographerDto dto, CancellationToken cancellationToken);
        Task<int> CreateCameraman(UpdateCameramanDto dto, CancellationToken cancellationToken);
        Task<int> CreateRestaurant(UpdateRestaurantDto dto, CancellationToken cancellationToken);

        //Change
        Task<int> ChangeWedding(int weddingId, UpdateWeddingDto dto, CancellationToken cancellationToken);
        Task<int> ChangeBride(int brideId, UpdateBrideDto dto, CancellationToken cancellationToken);
        Task<int> ChangeGroom(int groomId, UpdateGroomDto dto, CancellationToken cancellationToken);
        Task<int> ChangePhotographer(int photographerId, UpdatePhotographerDto dto, CancellationToken cancellationToken);
        Task<int> ChangeCameraman(int cameramanId, UpdateCameramanDto dto, CancellationToken cancellationToken);
        Task<int> ChangeRestaurant(int restaurantId, UpdateRestaurantDto dto, CancellationToken cancellationToken);

        //DeleteById
        Task<int> DeleteWeddingById(int id, CancellationToken cancellationToken);
        Task<int> DeleteBrideById(int id, CancellationToken cancellationToken);
        Task<int> DeleteGroomById(int id, CancellationToken cancellationToken);
        Task<int> DeletePhotographerById(int id, CancellationToken cancellationToken);
        Task<int> DeleteCameramanById(int id, CancellationToken cancellationToken);
        Task<int> DeleteRestaurantById(int id, CancellationToken cancellationToken);



    }
}
