using Application.Factories;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.User;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var result = await _userService.ExecuteGetAsync(id);

        if(result == null)
            return NotFound(_responseFactory.HandleResponse(result,(int)HttpStatus.NotFound));

        return Ok(_responseFactory.HandleResponse(result, (int)HttpStatus.OK));
    }

    [HttpPost]
    public async Task<IActionResult> PostUser([FromBody] CreateUserCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _userService.ExecuteCreateUserAsync(command);
        return Ok();
    }
}
