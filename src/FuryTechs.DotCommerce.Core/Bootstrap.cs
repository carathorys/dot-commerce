using FuryTechs.DotCommerce.Core.Database;
using FuryTechs.DotCommerce.Core.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FuryTechs.DotCommerce.Core
{
  public class Bootstrap
  {
    public Bootstrap(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    /// <summary>
    /// The configuration root
    /// </summary>
    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddHttpContextAccessor();
      services
        .AddDotCommerceAuthenticationSchemes<BaseDbContext>(Configuration)
        .AddDotCommerceDbContext<BaseDbContext>(Configuration)
        .AddDotCommerceGraphqlEndpoints(Configuration);
    }

    public void Configure(IApplicationBuilder app)
    {
      app
        .UseAuthentication()
        .UseAuthorization()
        .UseRouting()
        .UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
    }
  }
}