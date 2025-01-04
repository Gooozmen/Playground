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

    public async Task ExecuteCreateUserAsync(CreateUserCommand userCommand)
    {
        var user = _mapper.Map<User>(userCommand);
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    public async Task<UserFullResponse> ExecuteGetAsync(string userId)
    {
        var user = await _userRepository.GetAsync(new Guid(userId));
        var userResponse = _mapper.Map<UserFullResponse>(user);
        return userResponse;
    }

    public async Task ExecuteUpdateUserAsync(UpdateUserCommand userCommand)
    {
        var user = _mapper.Map<User>(userCommand);
        await _userRepository.UpdatePartialAsync(user);
        await _userRepository.SaveChangesAsync();
    }
}

public interface IUserService
{
    Task<UserFullResponse> ExecuteGetAsync(string userId);
    Task ExecuteCreateUserAsync(CreateUserCommand userCommand);
    Task ExecuteUpdateUserAsync(UpdateUserCommand userCommand);
}