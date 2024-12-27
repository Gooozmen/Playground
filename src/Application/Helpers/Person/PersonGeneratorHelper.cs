using Application.DTOs.Person;
using RandomNameGeneratorLibrary;

namespace Application.Helpers;

public class PersonGeneratorHelper : IPersonGeneratorHelper
{
    readonly INumericHelper _numericHelper;
    readonly IPersonNameGenerator _personNameGenerator;

    public PersonGeneratorHelper()
    {
        _personNameGenerator = new PersonNameGenerator();
        _numericHelper = new NumericHelper();
    }
    public PersonGeneratorHelper(INumericHelper numericHelper,
                                 IPersonNameGenerator personNameGenerator)
    {
        _personNameGenerator = personNameGenerator;
        _numericHelper = numericHelper;
    }

    public PersonDto GenerateRandom()
    {
        var person = new PersonDto
        {
            Id = Guid.NewGuid(),
            FirstName = _personNameGenerator.GenerateRandomFirstName(),
            LastName = _personNameGenerator.GenerateRandomLastName(),
            Age = _numericHelper.GenerateRandomNumber(10, 18)
        };

        return person;
    }
}
