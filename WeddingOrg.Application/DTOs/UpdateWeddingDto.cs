using System.ComponentModel.DataAnnotations;

namespace WeddingOrg.Application.DTOs
{

    public record UpdateWeddingDto(string dateOfSigningTheContract, string dateOfTheWedding,
            string brideName, string bridePhoneNumber,
            string brideEmail, string brideInstagram,
            string groomName, string groomPhoneNumber,
            string groomEmail, string groomInstagram,
            int SelectedPhotographerId, int SelectedCameramanId, int SelectedRestaurantId);
    public record UpdateBrideDto(string brideName, string bridePhoneNumber,
            string brideEmail, string brideInstagram);
    public record UpdateGroomDto(string groomName, string groomPhoneNumber,
            string groomEmail, string groomInstagram);
    public record UpdatePhotographerDto(string photographerName, string photographerFacebook, string photographerInstagram);

    public record UpdateRestaurantDto(string restaurantName, string restaurantFacebook, string restaurantInstagram);
    public record UpdatePhotoCameraRestaurantDto(string photographerFacebook, string photographerInstagram,
        string cameramanFacebook, string cameramanInstagram,
        string restaurantFacebook, string restaurantInstagram);
    public record UpdateWeddingBrideGroomDto(string dateOfSigningTheContract, string dateOfTheWedding,
            string brideName, string bridePhoneNumber,
            string brideEmail, string brideInstagram,
            string groomName, string groomPhoneNumber,
            string groomEmail, string groomInstagram);
    //public record UpdateFullWeddingDto(string dateOfSigningTheContract, string dateOfTheWedding,
    //        string brideName, string bridePhoneNumber,
    //        string brideEmail, string brideInstagram,
    //        string groomName, string groomPhoneNumber,
    //        string groomEmail, string groomInstagram,
    //        string photographerFacebook, string photographerInstagram,
    //        string cameramanFacebook, string cameramanInstagram,
    //        string restaurantFacebook, string restaurantInstagram);
}
