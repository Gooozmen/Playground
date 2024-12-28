using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Core;
using Application.Factories;
using Application.Helpers;
using Shared.Enums;

namespace Presentation.Controllers;

public class PersonController : CoreController
{
    private readonly IResponseFactory _responseFactory;
    private readonly IPersonGeneratorHelper _personGeneratorHelper;

    public PersonController(IResponseFactory responseFactory, 
                            IPersonGeneratorHelper personGeneratorHelper)
    {
        _responseFactory = responseFactory;
        _personGeneratorHelper = personGeneratorHelper;
    }

    [Route("GetMock")]
    [HttpGet]
    public IActionResult GetPerson()
    {
        var personMock = _personGeneratorHelper.GenerateRandom();
        var result = _responseFactory.HandleResponse(personMock,(int)HttpStatus.OK);

        return Ok(result);
    }
}
