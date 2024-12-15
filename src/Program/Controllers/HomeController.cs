using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Core;

namespace Presentation.Controllers;

public class HomeController : CoreController
{
    [Route("Access")]
    public IActionResult Index()
    {
        return Ok();
    }
}
