using FluentAssertions;
using WeddingOrg.Application.Models.Restaurants.DTOs;
using WeddingOrg.Application.Models.Weddings.Commands;
using WeddingOrg.Application.Models.Weddings.DTOs;

public class CreateWeddingCommandValidatorTests
{
    private readonly CreateWeddingCommandValidator _validator = new CreateWeddingCommandValidator();

    [Fact]
    public void GivenValidWeddingDto_WhenValidating_ShouldNotHaveErrors()
    {
        var dto = new WeddingDto("2023-05-20", "2023-06-10", "Bride Name", "1234567890", "bride@example.com", "bride_insta", "Groom Name", "0987654321", "groom@example.com", "groom_insta");

        var result = _validator.Validate(new CreateWeddingCommand(dto));

        result.IsValid.Should().BeTrue();
    }
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("    ")]
    public void GivenEmptyDateOfTheWedding_WhenValidating_ShouldHaveError(string dateOfTheWedding)
    {
        var dto = new WeddingDto("2023-05-20", dateOfTheWedding, "Bride Name", "1234567890", "bride@example.com", "bride_insta", "Groom Name", "0987654321", "groom@example.com", "groom_insta");

        var result = _validator.Validate(new CreateWeddingCommand(dto));

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "WeddingDto.dateOfTheWedding");
    }
    [Theory]
    [InlineData("2022-05-20")]
    [InlineData("2023-12-31")]
    public void GivenValidDateOfTheWedding_WhenValidating_ShouldNotHaveErrors(string dateOfTheWedding)
    {
        var dto = new WeddingDto("2023-05-20", dateOfTheWedding, "Bride Name", "1234567890", "bride@example.com", "bride_insta", "Groom Name", "0987654321", "groom@example.com", "groom_insta");

        var result = _validator.Validate(new CreateWeddingCommand(dto));

        result.IsValid.Should().BeTrue();
    }
    [Fact]
    public void GivenInvalidDateOfTheWedding_WhenValidating_ShouldHaveError()
    {
        var dto = new WeddingDto("2023-05-20", "invalid-date", "Bride Name", "1234567890", "bride@example.com", "bride_insta", "Groom Name", "0987654321", "groom@example.com", "groom_insta");

        var result = _validator.Validate(new CreateWeddingCommand(dto));

        result.IsValid.Should().BeFalse();
            result.Errors.Select(e => e.ErrorMessage).Should().BeEquivalentTo("Only numbers and signs are allowed.");
    }
    [Theory]
    [InlineData("2022-05-20")]
    [InlineData("2023-12-31")]
    public void GivenValidDateOfSigningTheContract_WhenValidating_ShouldNotHaveErrors(string dateOfSigningTheContract)
    {
        var dto = new WeddingDto(dateOfSigningTheContract, "2022-05-20", "Bride Name", "1234567890", "bride@example.com", "bride_insta", "Groom Name", "0987654321", "groom@example.com", "groom_insta");

        var result = _validator.Validate(new CreateWeddingCommand(dto));

        result.IsValid.Should().BeTrue();
    }
}
