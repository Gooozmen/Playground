
using Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.User;

public class CreateUserCommand
{
    public string RoleId { get; set; } = "C1";
    public string FirstName { get; set; } = "N/A";
    public string LastName { get; set; } = "N/A";
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }
}

public class UpdateUserCommand
{
    [Required]
    public Guid Id { get; set; }
    public string? RoleId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [PasswordPropertyText]
    public string? Password { get; set; }
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