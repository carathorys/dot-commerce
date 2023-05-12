using FuryTechs.DotCommerce.Core.Database.Base;
using FuryTechs.DotCommerce.Core.Database.Identity;

namespace FuryTechs.DotCommerce.Core.Database.Customer
{
  public class Customer : DotCommerceEntity
  {
    /// <summary>
    /// Title of the customer
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// First name of the customer 
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Last name of the customer
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Phone number of the customer
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// If the customer is not a guest, a user should belong to him/her.
    /// </summary>
    public User? User { get; set; }
  }
}