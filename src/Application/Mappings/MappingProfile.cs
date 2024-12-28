
using Shared.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Person
        CreateMap<Person, PersonResponse>();
        CreateMap<PersonResponse, Person>();
    }
}