using System.ComponentModel.DataAnnotations;

namespace WeddingOrg.DTOs
{
    
    public record UpdateWeddingDto(string dateOfSigningTheContract, string dateOfTheWedding);
    public record UpdateBrideDto(string brideName, string bridePhoneNumber,
            string brideEmail, string brideInstagram);
    public record UpdateGroomDto(string groomName, string groomPhoneNumber,
            string groomEmail, string groomInstagram);
    public record UpdatePhotographerDto(string photographerFacebook, string photographerInstagram);
    public record UpdateCameramanDto(string cameramanFacebook, string cameramanInstagram);
    public record UpdateRestaurantDto(string restaurantFacebook, string restaurantInstagram);
    public record UpdatePhotoCameraRestaurantDto(string photographerFacebook, string photographerInstagram, 
        string cameramanFacebook, string cameramanInstagram,
        string restaurantFacebook, string restaurantInstagram);
    public record UpdateWeddingBrideGroomDto(string dateOfSigningTheContract, string dateOfTheWedding,
            string brideName, string bridePhoneNumber,
            string brideEmail, string brideInstagram,
            string groomName, string groomPhoneNumber,
            string groomEmail, string groomInstagram);


}
