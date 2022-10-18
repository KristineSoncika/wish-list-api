using Microsoft.AspNetCore.Mvc;
using WishList.Core.Entities;
using WishList.Core.Services;
using WishList.Core.Validations;

namespace WishList.Controllers;

[Route("api/wishlist")]
[ApiController]
public class WishListController : ControllerBase
{
    private readonly IEntityService<Item> _entityService;
    private readonly IEnumerable<IItemValidator> _validators;

    public WishListController(IEntityService<Item> entityService, IEnumerable<IItemValidator> validators)
    {
        _entityService = entityService;
        _validators = validators;
    }
    
    [HttpPost]
    [Route("add")]
    public IActionResult CreateItem(Item item)
    {
        if (!_validators.All(v => v.IsValid(item)))
        {
            return BadRequest("Item name or description is null or empty");
        }
        
        try
        {
            var response = _entityService.Create(item);
            return Ok(response);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpDelete]
    [Route("delete/{id}")]
    public IActionResult DeleteItem(int id)
    {
        try
        {
            var response = _entityService.Delete(id);
            return Ok(response);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpPut]
    [Route("update")]
    public IActionResult UpdateItem(Item item)
    {
        if (!_validators.All(v => v.IsValid(item)))
        {
            return BadRequest("Item name or description is null or empty");
        } 
        
        try
        {
            var response = _entityService.Update(item);
            return Ok(response);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpGet]
    [Route("all")]
    public IActionResult GetAllItems()
    {
        try
        {
            var items = _entityService.GetAll();

            if (items == null) return NotFound();
            return Ok(items);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("get/{id}")]
    public IActionResult GetItemById(int id)
    {
        try
        {
            var item = _entityService.GetById(id);
            
            if (item == null) return NotFound("Item not found.");
            return Ok(item);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}