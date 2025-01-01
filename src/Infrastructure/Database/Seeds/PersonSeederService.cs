using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Seeds;

public class PersonSeederService : ISeederService
{
    private readonly PlaygroundDbContext _context;

    public PersonSeederService(PlaygroundDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (!await _context.Persons.AnyAsync())
        {
            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", Age = 30 },
                new Person { FirstName = "Jane", LastName = "Smith", Age = 25 }
            };

            await _context.Persons.AddRangeAsync(people);
        }
    }
}

