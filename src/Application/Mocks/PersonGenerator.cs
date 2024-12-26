using Common.Helpers;
using Domain.Entities;
using RandomNameGeneratorLibrary;

namespace Common.Mocks;

public class PersonGenerator
{
    readonly PersonNameGenerator nameGenerator;

    public PersonGenerator()
    {
        nameGenerator = new PersonNameGenerator();
    }

    public Person GenerateRandom()
    {
        var PersonMock = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = nameGenerator.GenerateRandomFirstName(),
            LastName = nameGenerator.GenerateRandomLastName(),
            Age = NumericHelper.GenerateRandomNumber(10, 18)
        };

        return PersonMock;
    }
}
