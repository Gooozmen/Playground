using Shared.DTOs;

namespace Shared.Helpers;

public interface IPersonGeneratorHelper
{
    PersonResponse GenerateRandom();
}