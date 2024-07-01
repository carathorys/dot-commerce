using FuryTechs.DotCommerce.Core.Database;

using Microsoft.EntityFrameworkCore;

namespace FuryTechs.DotCommerce.WebAPI;

public class WebDbContext : BaseDbContext<Guid>
{
  public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
  {
        
  }
}