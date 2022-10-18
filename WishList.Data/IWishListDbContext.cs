using Microsoft.EntityFrameworkCore;
using WishList.Core.Entities;

namespace WishList.Data;

public interface IWishListDbContext
{
    DbSet<Item> Items { get; set; }
    int SaveChanges();
    Task<int> SaveChangesAsync();
}