using WishList.Core.Entities;

namespace WishList.Core.Validations;

public interface IItemValidator
{
    bool IsValid(Item item);
}