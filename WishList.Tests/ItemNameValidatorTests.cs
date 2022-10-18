using FluentAssertions;
using WishList.Core.Entities;
using WishList.Core.Validations;

namespace WishList.Tests;

public class ItemNameValidatorTests
{
    private readonly IItemValidator _nameValidator = new ItemNameValidator();
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void IsValid_NameIsNullOrEmpty_ReturnsFalse(string name)
    {
        // Arrange
        var item = new Item
        {
            Id = 1,
            Name = name,
            Description = "description"
        };
        
        // Act
        var result = _nameValidator.IsValid(item);
        
        // Assert
        result.Should().Be(false);
    }

    [Fact]
    public void IsValid_NameIsValid_ReturnsTrue()
    {
        // Arrange
        var item = new Item
        {
            Id = 1,
            Name = "name",
            Description = "description"
        };
        
        // Act
        var result = _nameValidator.IsValid(item);
        
        // Assert
        result.Should().Be(true);
    }
}