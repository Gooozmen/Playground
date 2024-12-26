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

    [HttpGet("current")]
    public async Task<IActionResult> GetCurrentWeather([FromQuery] string location)
    {
        var response = _weatherService.GetWeatherForLocation(location);
        return response.Result.IsSuccess switch
        {
            true => Ok(response.Result),
            false => BadRequest(response.Result)
        };
    }
}   