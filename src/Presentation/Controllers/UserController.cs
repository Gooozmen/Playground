using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class UserController : CoreController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetUser")]
    public IActionResult Get()
    {
        var result = _userService.ExecuteGetAsync();
        return Ok(result.Result);
    }
}
