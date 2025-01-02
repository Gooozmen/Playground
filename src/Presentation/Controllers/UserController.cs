using Application.Factories;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;

namespace Presentation.Controllers;

public class UserController : CoreController
{
    private readonly IUserService _userService;
    private readonly IResponseFactory _responseFactory;


    public UserController(IUserService userService,IResponseFactory responseFactory)
    {
        _userService = userService;
        _responseFactory = responseFactory;
    }

    [HttpGet("GetFullUser")]
    public async Task<IActionResult> Get()
    {
        var result = await _userService.ExecuteGetAsync();
        var response = _responseFactory.HandleResponse(result,(int)HttpStatus.OK);
        return Ok(response);
    }
}
