using Domain.Options;
using Application.Contracts.Responses;
using Infrastructure.ApplicationHttpClient;

namespace Application.Services;

public interface IWeatherService
{
    Task<ResponseBase<WeatherstackResponse>> GetWeatherForLocation(string location);
}
