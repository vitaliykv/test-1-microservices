using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var ocelot_json_file = builder.Configuration.GetValue<string>("Ocelot_json");
//ocelot-compose.json
// Ocelot_json
builder.Configuration.AddJsonFile(ocelot_json_file);

builder.Services.AddOcelot();


var app = builder.Build();

app.UseOcelot().Wait();

app.MapGet("/", () => "Hello World!");

app.Run();

