using FuryTechs.DotCommerce.Core;

namespace FuryTechs.DotCommerce.WebAPI
{
  public static class Program
  {
    public static void Main(params string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
      return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(x => x.UseStartup<Bootstrap>());
    }
  }
}