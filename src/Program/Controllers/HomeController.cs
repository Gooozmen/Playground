using Microsoft.AspNetCore.Mvc;

namespace Playground.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        return Ok();
    }
}
