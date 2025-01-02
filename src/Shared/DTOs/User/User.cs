
using Domain.Entities;

namespace Shared.DTOs.User;

public class CreateUserCommand
{
    public string RoleId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UserFullResponse : Auditable
{
    public Guid Id { get; set; }
    public string RoleId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}