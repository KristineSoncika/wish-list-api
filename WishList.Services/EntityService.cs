using WishList.Core.Entities;
using WishList.Core.Services;
using WishList.Data;

namespace WishList.Services;

public class EntityService : IEntityService<Item>
{
    private readonly IWishListDbContext _context;

    public EntityService(IWishListDbContext context)
    {
        _context = context;
    }

    public ServiceResponse Create(Item item)
    {
        var response = new ServiceResponse();

        try
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            response.Success = true;
            response.Message = "Item successfully created";
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = $"Error: {e.Message}";
        }

        return response;
    }

    public ServiceResponse Delete(int id)
    {
        var response = new ServiceResponse();

        try
        {
            var item = GetById(id);
            
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
                response.Success = true;
                response.Message = "Item successfully deleted";
            }
            else
            {
                response.Success = false;
                response.Message = "Item not found";
            }
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = $"Error: {e.Message}";
        }

        return response;
    }

    public ServiceResponse Update(Item item)
    {
        var response = new ServiceResponse();
        
        try
        {
            var itemToUpdate = GetById(item.Id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.Description = item.Description;
                _context.SaveChanges();
                response.Success = true;
                response.Message = "Item successfully updated";
            }
            else
            {
                response.Success = false;
                response.Message = "Item not found";
            }
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = $"Error: {e.Message}";
        }

        return response;
    }

    public List<Item> GetAll()
    {
        return _context.Items.ToList();
    }

    public Item GetById(int id)
    {
        return _context.Items.Find(id);
    }
}