using WishList.Core.Entities;

namespace WishList.Core.Validations;

public class ItemDescriptionValidator : IItemValidator
{
    public bool IsValid(Item item)
    {
        return !string.IsNullOrWhiteSpace(item.Description);
    }
}