using WishList.Core.Entities;
using WishList.Core.Services;

namespace WishList.Services;

public class UserService : IUserService
{
    public string GetUserNames(IEnumerable<User> users)
    {
        return string.Join(", ", users.Select(user => user.Name));
    }
}