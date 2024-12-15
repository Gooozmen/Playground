using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Core;
using Domain.Entities;


namespace Presentation.Controllers;

public class PersonController : CoreController
{
    [Route("GetPerson")]
    [HttpGet]
    public ActionResult<Person> GetPerson()
    {
        var id = Guid.NewGuid();
        var firstName = "Juan";
        var lastName = "Guzman";
        var age = 19;

        Person personResult = new Person(id, firstName, lastName, age);

        return Ok(personResult);
    }
}
