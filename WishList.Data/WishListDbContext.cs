using Microsoft.EntityFrameworkCore;
using WishList.Core.Entities;

namespace WishList.Data;

public class WishListDbContext : DbContext, IWishListDbContext
{
    public WishListDbContext(DbContextOptions options)
        : base(options) { }
    
    public DbSet<Item> Items { get; set; }
    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}