using WishList.Core.Entities;

namespace WishList.Core.Services;

public interface IUserService
{
    public string GetUserNames(IEnumerable<User> users);
}