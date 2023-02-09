using WeddingOrg.Application.Cameramen.DTOs;
using WeddingOrg.Application.DTOs;
using WeddingOrg.Domain.Entities;

namespace WeddingOrg.Application.Interfaces
{
    public interface IWeddingsRepository
    {
        // Get        
        Task<IEnumerable<Wedding>> GetWeddings(CancellationToken cancellationToken);
        Task<IEnumerable<Photographer>> GetPhotographers(CancellationToken cancellationToken);
        Task<IEnumerable<Cameraman>> GetCameramen(CancellationToken cancellationToken);
        Task<IEnumerable<Restaurant>> GetRestaurants(CancellationToken cancellationToken);

        //GetById
        Task<Wedding> GetWeddingById(int id, CancellationToken cancellationToken);
        Task<Bride> GetBrideById(int id, CancellationToken cancellationToken);
        Task<Groom> GetGroomById(int id, CancellationToken cancellationToken);
        Task<Photographer> GetPhotographerById(int id, CancellationToken cancellationToken);
        Task<Cameraman> GetCameramanById(int id, CancellationToken cancellationToken);
        Task<Restaurant> GetRestaurantById(int id, CancellationToken cancellationToken);

        //Create 
        Task<int> CreateWeedingBrideGroom(UpdateWeddingBrideGroomDto dto);
        Task<int> CreateFullWeedingRepository(UpdateFullWeddingDto dto);
        Task<int> CreatePhotographer(UpdatePhotographerDto dto);
        Task<int> CreateCameraman(CameramanDto dto);
        Task<int> CreateRestaurant(UpdateRestaurantDto dto);

        //Change
        Task<int> ChangeWedding(int weddingId, UpdateWeddingDto dto, CancellationToken cancellationToken);
        Task<int> ChangeBride(int brideId, UpdateBrideDto dto, CancellationToken cancellationToken);
        Task<int> ChangeGroom(int groomId, UpdateGroomDto dto, CancellationToken cancellationToken);
        Task<int> ChangePhotographer(int photographerId, UpdatePhotographerDto dto, CancellationToken cancellationToken);
        Task<int> ChangeCameraman(int cameramanId, CameramanDto dto, CancellationToken cancellationToken);
        Task<int> ChangeRestaurant(int restaurantId, UpdateRestaurantDto dto, CancellationToken cancellationToken);

        //DeleteById
        Task<int> DeleteWeddingById(int id, CancellationToken cancellationToken);
        Task<int> DeleteBrideById(int id, CancellationToken cancellationToken);
        Task<int> DeleteGroomById(int id, CancellationToken cancellationToken);
        Task<int> DeletePhotographerById(int id, CancellationToken cancellationToken);
        Task<int> DeleteCameramanById(int id, CancellationToken cancellationToken);
        Task<int> DeleteRestaurantById(int id, CancellationToken cancellationToken);

        // Add
        Task<Wedding> AddPhotographerToWedding(int weddingId, int photographerId);
        Task<Wedding> AddCameramanToWedding(int weddingId, int cameramanId);
        Task<Wedding> AddRestaurantToWedding(int weddingId, int restaurantId);
    }
}
