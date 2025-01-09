using Microsoft.AspNetCore.Identity;

namespace Domain.Identities;

public class ApplicationUser : IdentityUser<Guid>
{

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }

}
