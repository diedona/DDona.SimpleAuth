using DDona.SimpleAuth.Api;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration, builder.Host);
startup.ConfigureJson();
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app);

app.Run();