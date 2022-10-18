using FluentAssertions;
using WishList.Core.Entities;
using WishList.Core.Validations;

namespace WishList.Tests;

public class ItemDescriptionValidatorTests
{
    private readonly IItemValidator _descriptionValidator = new ItemDescriptionValidator();

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void IsValid_DescriptionIsNullOrEmpty_ReturnsFalse(string description)
    {
        // Arrange
        var item = new Item
        {
            Id = 1,
            Name = "name",
            Description = description
        };
        
        // Act
        var result = _descriptionValidator.IsValid(item);
        
        // Assert
        result.Should().Be(false);
    }

    [Fact]
    public void IsValid_DescriptionIsValid_ReturnsTrue()
    {
        // Arrange
        var item = new Item
        {
            Id = 1,
            Name = "name",
            Description = "description"
        };
        
        // Act
        var result = _descriptionValidator.IsValid(item);
        
        // Assert
        result.Should().Be(true);
    }
}