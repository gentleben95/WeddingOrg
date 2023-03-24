using FluentAssertions;
using WeddingOrg.Application.Models.Restaurants.Commands;
using WeddingOrg.Application.Models.Restaurants.DTOs;

public class CreateRestaurantCommandValidatorTests
{
    private CreateRestaurantCommandValidator _validator;

    public CreateRestaurantCommandValidatorTests()
    {
        _validator = new CreateRestaurantCommandValidator();
    }

    [Fact]
    public void Should_Not_Have_Error_When_Valid()
    {
        var dto = new RestaurantDto("Restaurant Name", "https://www.facebook.com/restaurant", "https://www.instagram.com/restaurant");
        var command = new CreateRestaurantCommand(dto);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var dto = new RestaurantDto("", "https://www.facebook.com/restaurant", "https://www.instagram.com/restaurant");
        var command = new CreateRestaurantCommand(dto);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle()
                          .Which.PropertyName.Should().Be("RestaurantDto.restaurantName");
    }

    [Fact]
    public void Should_Have_Error_When_Name_Exceeds_Maximum_Length()
    {
        var dto = new RestaurantDto(new string('a', 51), "https://www.facebook.com/restaurant", "https://www.instagram.com/restaurant");
        var command = new CreateRestaurantCommand(dto);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle()
                          .Which.PropertyName.Should().Be("RestaurantDto.restaurantName");
    }

    [Fact]
    public void Should_Not_Have_Error_When_Facebook_Is_Null()
    {
        var dto = new RestaurantDto("Restaurant Name", null, "https://www.instagram.com/restaurant");
        var command = new CreateRestaurantCommand(dto);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }  
    [Fact]
    public void Should_Have_Error_When_Facebook_Exceeds_Maximum_Length()
    {
        var dto = new RestaurantDto("My Restaurant", new string('a', 61), "https://www.instagram.com/myrestaurant");
        var command = new CreateRestaurantCommand(dto);
        var validator = new CreateRestaurantCommandValidator();

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle()
                  .Which.PropertyName.Should().Be("RestaurantDto.restaurantFacebook");
    }
    [Fact]
    public void Should_Not_Have_Error_When_Instagram_Is_Null()
    {
        var dto = new RestaurantDto("Restaurant Name", "https://www.facebook.com/restaurant", null);
        var command = new CreateRestaurantCommand(dto);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public void Should_Have_Error_When_Instagram_Exceeds_Maximum_Length()
    {
        var dto = new RestaurantDto("Restaurant Name", "https://www.facebook.com/restaurant", new string('a', 61));
        var command = new CreateRestaurantCommand(dto);

        var result = _validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle()
              .Which.PropertyName.Should().Be("RestaurantDto.restaurantInstagram");
    }
}
