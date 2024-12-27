using System;
using Xunit;
using Application.Helpers;
using Moq;

namespace Tests.Application.Helpers;

public class PersonGeneratorHelperTests
{
    private readonly PersonGeneratorHelper _personGeneratorHelper;

    public PersonGeneratorHelperTests()
    {
        _personGeneratorHelper = new PersonGeneratorHelper();
    }

    [Fact]
    public void GenerateRandom_ShouldReturnPersonWithValidProperties()
    {
        // Act
        var personIntent = _personGeneratorHelper.GenerateRandom();

        // Assert
        Assert.NotNull(personIntent);
        Assert.NotEqual(Guid.Empty, personIntent.Id);
        Assert.False(string.IsNullOrEmpty(personIntent.FirstName));
        Assert.False(string.IsNullOrEmpty(personIntent.LastName));
        Assert.InRange(personIntent.Age, 10, 18);
    }
}
