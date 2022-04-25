using Application.Server;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
var startUp = new Startup();
startUp.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
startUp.Configure(app, app.Environment);

app.Run();
