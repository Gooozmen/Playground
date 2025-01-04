
using Shared.DTOs;
using AutoMapper;
using Domain.Entities;
using Shared.DTOs.User;

namespace Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Person
        CreateMap<Person, PersonResponse>();
        CreateMap<PersonResponse, Person>();

        //User
        CreateMap<CreateUserCommand, User>();
        CreateMap<User,UserFullResponse>();
        CreateMap<UpdateUserCommand,User>();
    }
}