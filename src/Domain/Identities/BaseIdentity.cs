using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identities;

public abstract class BaseIdentity : IdentityUser<Guid>
{
}
