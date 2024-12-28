using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Core;
using Application.Factories;
using Application.Services;
using Shared.Enums;
using Shared.Helpers;
using Shared.DTOs;

namespace Presentation.Controllers;

public class WeatherController : CoreController
{
    private readonly IResponseFactory _responseFactory;
    private readonly IWeatherService _weatherService;
    private readonly IJsonHelper _jsonHelper;


    public WeatherController(IResponseFactory responseFactory,
                             IWeatherService weatherService,
                             IJsonHelper jsonHelper)
    {
        _responseFactory = responseFactory;
        _weatherService = weatherService;
        _jsonHelper = jsonHelper;
    }

    [HttpGet("current")]
    public async Task<IActionResult> GetCurrentWeather([FromQuery] string location)
    {
        var response =  await _weatherService.GetWeatherForLocation(location);
        var success = _weatherService.ValidateJsonResponse(response);

        if (success)
        {
            var data = _jsonHelper.ConvertJsonObjectToEntity<WeatherstackResponse>(response);
            var statusCode = (int)HttpStatus.OK;
            var statusDescription = HttpStatusDescriptions.GetDescription(statusCode);
            var result = _responseFactory.HandleResponse(response, statusCode, statusDescription);
            return Ok(result);
        }
        else
        {
            var data = _jsonHelper.ConvertJsonObjectToEntity<WeatherstackError>(response);
            var statusCode = (int)HttpStatus.BadRequest;
            var statusDescription = HttpStatusDescriptions.GetDescription(statusCode);
            var result = _responseFactory.HandleResponse(data, statusCode, statusDescription);
            return Ok(result);
        }

    }
}   