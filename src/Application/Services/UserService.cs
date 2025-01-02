using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Shared.DTOs.User;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<User> ExecuteCreateUserAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<UserFullResponse> ExecuteGetAsync()
    {
        var key = Guid.Parse("774746D8-3A5D-4ACA-A740-2488CF2337EF");
        var user = _userRepository.GetAsync(key).Result;
        var userResponse = _mapper.Map<UserFullResponse>(user);
        return userResponse;
    }
}

public interface IUserService
{
    Task<UserFullResponse> ExecuteGetAsync();
    Task<User> ExecuteCreateUserAsync();

}