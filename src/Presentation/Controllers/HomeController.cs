using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Core;

namespace Presentation.Controllers;

[Controller]
[Route("home")]
public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("Access")]
    public IActionResult Index()
    {
        return BadRequest();
    }
}
