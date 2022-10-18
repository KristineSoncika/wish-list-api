using FluentAssertions;
using WishList.Core.Entities;
using WishList.Core.Services;
using WishList.Services;

namespace WishList.Tests;

public class UserServiceTests
{
    private readonly IUserService _userService = new UserService();

    [Fact]
    public void GetUserNames_PassUserList_ReturnsString()
    {
        // Arrange
        var users = new List<User>
        {
            new() {Type = "user", Id = 150709, Name = "johnsmith", Email = "jsmith@example.com" },
            new() {Type = "user", Id = 150710, Name = "angelinasmith", Email = "asmith@example.com" },
            new() {Type = "user", Id = 150910, Name = "adamivanov", Email = "aivanov@another.org"}
        };
        const string userNames = "johnsmith, angelinasmith, adamivanov";
        
        // Act 
        var result = _userService.GetUserNames(users);
        
        // Assert
        result.Should().Be(userNames);
    }
}