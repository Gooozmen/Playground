using Domain.Entities;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Presentation.Controllers;

public class EFCoreController : CoreController
{
    private readonly ApplicationDbContext _context;

    public EFCoreController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
       return Ok();
    }
}
