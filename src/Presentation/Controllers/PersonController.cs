using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Core;
using Common.Mocks;
using Common.HttpResponses;


namespace Presentation.Controllers;

public class PersonController : CoreController
{
    [Route("GetMock")]
    [HttpGet]
    public JsonResult GetPerson()
    {
        var personGenerator = new PersonGenerator();
        var personMock = personGenerator.GenerateRandom();
        var js = new JsonResult(personMock);

        //return ContentResultFactory.Success(personGenerator);
        return js;
    }
}
