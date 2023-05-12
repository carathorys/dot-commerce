using Microsoft.AspNetCore.Identity;

namespace FuryTechs.DotCommerce.Core.Database.Identity
{
  public class User : IdentityUser<Guid>
  {
    public string? Title { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public string? PhoneNumber { get; set; }
  }
}