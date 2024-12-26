﻿using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Core;
using Common.Mocks;
using Application.Factories;
using Domain.Entities;

namespace Presentation.Controllers;

public class PersonController : CoreController
{
    private readonly IResponseFactory _responseFactory;
    public PersonController(IResponseFactory responseFactory)
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
}
