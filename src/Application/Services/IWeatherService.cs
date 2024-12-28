using Shared.Contracts.Responses;
using Shared.DTOs;

namespace Application.Services;

public interface IWeatherService
{
    Task<ResponseBase<WeatherstackResponse>> GetWeatherForLocation(string location);
}
