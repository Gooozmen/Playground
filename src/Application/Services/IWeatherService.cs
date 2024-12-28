using Shared.Contracts.Responses;
using Shared.DTOs;
using System.Text.Json.Nodes;

namespace Application.Services;

public interface IWeatherService
{
    Task<JsonObject> GetWeatherForLocation(string location);
    bool ValidateJsonResponse(JsonObject json);
}
