using FluentAssertions;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingOrg.Application.Cameramen.Commands;
using WeddingOrg.Application.Cameramen.DTOs;

namespace WeddingOrg.Application.Tests.Cameramen.Commands;

public class CreateCameramanCommandValidatorTests
{
    private readonly CreateCameramanCommandValidator _validator;

    public CreateCameramanCommandValidatorTests()
    {
        _validator = new CreateCameramanCommandValidator();
    }

    [Fact]
    public void ShouldHaveErrorWhenCameramanNameIsEmpty()
    {
        var command = new CreateCameramanCommand(new CameramanDto("", null, null));

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.CameramanDto.cameramanName)
              .WithErrorMessage("Cameraman name is required.");
    }

    [Fact]
    public void ShouldHaveErrorWhenCameramanNameIsTooLong()
    {
        var command = new CreateCameramanCommand(new CameramanDto("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", null, null));

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.CameramanDto.cameramanName)
              .WithErrorMessage("Cameraman name must not exceed 50 characters.");
    }

    [Fact]
    public void ShouldNotHaveErrorWhenCameramanNameIsValid()
    {
        var command = new CreateCameramanCommand(new CameramanDto("John Doe", null, null));

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ShouldHaveErrorWhenCameramanFacebookIsTooLong()
    {
        var command = new CreateCameramanCommand(new CameramanDto("John Doe", "https://www.facebook.com/this-is-a-very-long-url-that-exceeds-100-charactersedtshhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh", null));

        var result = _validator.TestValidate(command);

        result.Errors.Count.Should().BeGreaterThan(0);

        //result.ShouldHaveValidationErrorFor(x => x.CameramanDto.cameramanFacebook)
        //      .WithErrorMessage("Cameraman Facebook URL must not exceed 100 characters.");
    }

    [Fact]
    public void ShouldNotHaveErrorWhenCameramanFacebookIsNull()
    {
        var command = new CreateCameramanCommand(new CameramanDto("John Doe", null, null));

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ShouldHaveErrorWhenCameramanInstagramIsTooLong()
    {
        var command = new CreateCameramanCommand(new CameramanDto("John Doe", null, "https://www.instagram.com/this-is-a-very-long-url-that-exceeds-100-characters/"));

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.CameramanDto.cameramanInstagram)
              .WithErrorMessage("Cameraman Instagram URL must not exceed 100 characters.");
    }

    [Fact]
    public void ShouldNotHaveErrorWhenCameramanInstagramIsNull()
    {
        var command = new CreateCameramanCommand(new CameramanDto("John Doe", null, null));

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveAnyValidationErrors();
    }
}
