using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Core;
using Application.Factories;
using Application.Services;

namespace Presentation.Controllers;

public class WeatherController : CoreController
{
    private readonly IResponseFactory _responseFactory;
    private readonly IWeatherService _weatherService;


    public WeatherController(IResponseFactory responseFactory,
                             IWeatherService weatherService)
    {
        _responseFactory = responseFactory;
        _weatherService = weatherService;
    }

    [Route("Current")]
    [HttpGet]
    public async Task<IActionResult> GetCurrentWeather([FromQuery] string location)
    {
        var result = _weatherService.Execute();
        return result switch
        {
            // Match specific object values
            { IsSuccess: false} => Ok(result),
            { IsSuccess: true} => BadRequest(result)
        };
    }
}   