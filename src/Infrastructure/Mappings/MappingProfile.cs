
using Shared.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Identities;
using Shared.DTOs.ApplicationUser;
using Shared.DTOs.User;

namespace Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<CreateUserCommand, User>();
        CreateMap<User,UserFullResponse>();
        CreateMap<UpdateUserCommand,User>();
        
        //ApplicationUser
        CreateMap<ApplicationUserCommand, ApplicationUser>();
        CreateMap<ApplicationUser, ApplicationUserCommand>();
    }
}