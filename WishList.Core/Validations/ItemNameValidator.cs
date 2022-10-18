using WishList.Core.Entities;

namespace WishList.Core.Validations;

public class ItemNameValidator : IItemValidator
{
    public bool IsValid(Item item)
    {
        return !string.IsNullOrWhiteSpace(item.Name);
    }
}