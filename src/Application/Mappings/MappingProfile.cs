
using Shared.DTOs;
using AutoMapper;
using Domain.Entities;
using Shared.DTOs.User;

namespace Application.Mappings;

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


    }
}