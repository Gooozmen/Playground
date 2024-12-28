using Shared.DTOs;

namespace Application.Helpers;

public interface IPersonGeneratorHelper
{
    PersonResponse GenerateRandom();
}