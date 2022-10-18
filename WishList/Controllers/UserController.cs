using Microsoft.AspNetCore.Mvc;
using WishList.Core.Services;
using WishList.Models;

namespace WishList.Controllers;

[Route("api")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    [Route("user-names")]
    public IActionResult GetUserNames(UserList users)
    {
        try
        {
            var result = _userService.GetUserNames(users.Users);
            
            if (result == null) return NotFound();
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}