using Application.Factories;
using Infrastructure.Managers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shared.DTOs.ApplicationUser;
using Shared.Enums;

namespace Presentation.Controllers;

public class IdentityController : CoreController
{
    private readonly IServiceProvider _serviceProvider;

    public IdentityController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [HttpPost("identity")]
    public async Task<IActionResult> CreateIdentity([FromBody] ApplicationUserCommand command)
    {   
        var responseFactory = _serviceProvider.GetRequiredService<IResponseFactory>();
        var applicationUserManager = _serviceProvider.GetRequiredService<IApplicationUserManager>();
        var result = await applicationUserManager.CreateApplicationUserAsync(command);
        if (result.Succeeded)
            return Ok(responseFactory.HandleResponse(result, (int)HttpStatus.Created));
        return BadRequest(result.Errors);
    }
    
    
}