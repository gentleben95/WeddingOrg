using System.ComponentModel.DataAnnotations;

namespace WeddingOrg.DTOs
{
    
    public record UpdateWeddingDto(string dateOfSigningTheContract, string dateOfTheWedding);
    public record UpdateBrideDto(string brideName, string bridePhoneNumber,
            string brideEmail, string brideInstagram);
    public record UpdateGroomDto(string groomName, string groomPhoneNumber,
            string groomEmail, string groomInstagram);
    public record UpdatePhotographer(string photographerFacebook, string photographerInstagram);
    public record UpdateCameraman(string cameramanFacebook, string cameramanInstagram);
    public record UpdateRestaurant(string cameramanFacebook, string cameramanInstagram);
    public record UpdateWholeWeddingDto(string dateOfSigningTheContract, string dateOfTheWedding,
            string brideName, string bridePhoneNumber,
            string brideEmail, string brideInstagram,
            string groomName, string groomPhoneNumber,
            string groomEmail, string groomInstagram,
            string photographerFacebook, string photographerInstagram,
            string cameramanFacebook, string cameramanInstagram,
            string restaurantFacebook, string restaurantInstagram);

}
