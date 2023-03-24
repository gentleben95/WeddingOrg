using FluentAssertions;
using WeddingOrg.Application.Models.Photographers.Commands;
using WeddingOrg.Application.Models.Photographers.DTOs;

namespace WeddingOrg.Application.Tests.Models.Photographers.Commands
{
    public class CreatePhotographerCommandValidatorTests
    {
        private readonly CreatePhotographerCommandValidator _validator;

        public CreatePhotographerCommandValidatorTests()
        {
            _validator = new CreatePhotographerCommandValidator();
        }

        [Fact]
        public void GivenValidPhotographerDto_WhenValidating_ShouldNotHaveValidationError()
        {
            var photographerDto = new PhotographerDto("John Doe", "johndoe", "johndoe");

            var command = new CreatePhotographerCommand(photographerDto);
            var result = _validator.Validate(command);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void GivenPhotographerNameIsEmpty_WhenValidating_ShouldHaveValidationError()
        {
            var photographerDto = new PhotographerDto("", "johndoe", "johndoe");

            var command = new CreatePhotographerCommand(photographerDto);
            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.PropertyName.Should().Be("PhotographerDto.photographerName");
        }

        [Fact]
        public void GivenPhotographerNameIsTooLong_WhenValidating_ShouldHaveValidationError()
        {
            var photographerDto = new PhotographerDto(new string('x', 61), "johndoe", "johndoe");

            var command = new CreatePhotographerCommand(photographerDto);
            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.PropertyName.Should().Be("PhotographerDto.photographerName");
        }

        [Fact]
        public void GivenPhotographerFacebookIsTooLong_WhenValidating_ShouldHaveValidationError()
        {
            var photographerDto = new PhotographerDto("John Doe", new string('x', 61), "johndoe");

            var command = new CreatePhotographerCommand(photographerDto);
            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.PropertyName.Should().Be("PhotographerDto.photographerFacebook");
        }

        [Fact]
        public void GivenPhotographerInstagramIsTooLong_WhenValidating_ShouldHaveValidationError()
        {
            var photographerDto = new PhotographerDto("John Doe", "johndoe", new string('x', 61));

            var command = new CreatePhotographerCommand(photographerDto);
            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .Which.PropertyName.Should().Be("PhotographerDto.photographerInstagram");
        }
    }
}
