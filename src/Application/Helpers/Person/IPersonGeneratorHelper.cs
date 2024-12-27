using Application.DTOs.Person;

namespace Application.Helpers;

public interface IPersonGeneratorHelper
{
    PersonDto GenerateRandom();
}