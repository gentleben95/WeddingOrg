using FluentAssertions;
using WeddingOrg.Application.Models.Cameramen.Commands;
using WeddingOrg.Application.Models.Cameramen.DTOs;

public class CreateCameramanCommandValidatorTests
{
    private readonly CreateCameramanCommandValidator _validator;

    public CreateCameramanCommandValidatorTests()
    {
        _validator = new CreateCameramanCommandValidator();
    }

    [Fact]
    public void GivenValidCameramanDto_WhenValidatingCreateCameramanCommand_ShouldNotHaveValidationError()
    {
        // Arrange
        var dto = new CameramanDto("Test Name", "https://www.facebook.com/test", "https://www.instagram.com/test");

        // Act
        var result = _validator.Validate(new CreateCameramanCommand(dto));

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("          ")]
    public void GivenInvalidCameramanName_WhenValidatingCreateCameramanCommand_ShouldHaveValidationError(string cameramanName)
    {
        // Arrange
        var dto = new CameramanDto(cameramanName, "https://www.facebook.com/test", "https://www.instagram.com/test");

        // Act
        var result = _validator.Validate(new CreateCameramanCommand(dto));

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "CameramanDto.cameramanName");
    }

    [Fact]
    public void GivenCameramanNameWithMoreThan50Characters_WhenValidatingCreateCameramanCommand_ShouldHaveValidationError()
    {
        // Arrange
        var dto = new CameramanDto("123456789012345678901234567890123456789012345678901", "https://www.facebook.com/test", "https://www.instagram.com/test");

        // Act
        var result = _validator.Validate(new CreateCameramanCommand(dto));

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "CameramanDto.cameramanName");
    }

    [Fact]
    public void GivenCameramanFacebookWithMoreThan60Characters_WhenValidatingCreateCameramanCommand_ShouldHaveValidationError()
    {
        // Arrange
        var dto = new CameramanDto("Test Name", "https://www.facebook.com/testfacebooktestfacebooktestfacebooktest", "https://www.instagram.com/test");

        // Act
        var result = _validator.Validate(new CreateCameramanCommand(dto));

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "CameramanDto.cameramanFacebook" );
    }

    [Fact]
    public void GivenCameramanInstagramWithMoreThan60Characters_WhenValidatingCreateCameramanCommand_ShouldHaveValidationError()
    {
        // Arrange
        var dto = new CameramanDto("Test Name", "https://www.facebook.com/test", "https://www.instagram.com/testinstagramtestinstagramtest12345678910");

        // Act
        var result = _validator.Validate(new CreateCameramanCommand(dto));

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "CameramanDto.cameramanInstagram");
    }
}
