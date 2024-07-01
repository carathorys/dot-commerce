using FuryTechs.DotCommerce.Core;
using FuryTechs.DotCommerce.WebAPI;

var builder = WebApplication.CreateBuilder(args);

var bootstrap = new Bootstrap<Guid, WebDbContext>(builder.Configuration);
var services = builder.Services;
bootstrap.ConfigureServices(builder.Services);
var app = builder.Build();
bootstrap.Configure(app);

app.Run();
