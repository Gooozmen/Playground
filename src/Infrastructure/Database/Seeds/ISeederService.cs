using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Seeds;

public interface ISeederService
{
    Task SeedAsync();
}