using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Core;
using Common.Mocks;
using Presentation.Factories;
using Domain.Entities;
using Presentation.Responses;


namespace Presentation.Controllers;

public class PersonController : CoreController
{
    private readonly IResponseFactory<Person> _responseFactory;
    public PersonController(IResponseFactory<Person> responseFactory)
    {
        _responseFactory = responseFactory;
    }

    [Route("GetMock")]
    [HttpGet]
    public IActionResult GetPerson()
    {
        Response.StatusCode = 200;
        var personGenerator = new PersonGenerator();
        var personMock = personGenerator.GenerateRandom();
        var result = _responseFactory.Success(personMock);

        return Ok(result);
    }

    [Route("CreatePerson")]
    [HttpGet]
    public IActionResult GetPerson()
    {
        Response.StatusCode = 200;
        var personGenerator = new PersonGenerator();
        var personMock = personGenerator.GenerateRandom();
        var result = _responseFactory.Success(personMock);

        return Ok(result);
    }
}
