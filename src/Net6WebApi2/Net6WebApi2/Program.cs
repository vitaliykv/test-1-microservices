﻿using Net6WebApi2.DalCommon;
using Net6WebApi2.DalEfImpl;
using Net6WebApi2.DTO;
using Net6WebApi2.Middleware;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        //.AddFilter("Microsoft", LogLevel.Information)
        //.AddFilter("System", LogLevel.Information)
        //.AddFilter("LoggingConsoleApp.Program", LogLevel.Information)
        .ClearProviders()
        .AddConsole();
});

ILogger logger = loggerFactory.CreateLogger<Program>();
logger.LogInformation("Start Program 1 aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Connect to PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.UseNoteDbContext(connectionString);


//... rest of the code omitted for brevity
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//... rest of the code omitted for brevity

builder.UseNoteSrv();

WebApplication? app = builder.Build();
//... rest of the code omitted for brevity

// Migrate Note Database
app.NoteDatabaseMigrate();
logger.LogInformation("NoteDatabaseMigrate OK aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

app.UseMiddleware<RequestLoggingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.MapGet("/api/v1/notes/{id:int}", async (int id, INoteSrv noteSrv) =>
{
    return await noteSrv.FindNote(id)
            is Net6WebApi2.DalCommon.Models.Note n
                ? Results.Ok(new Note(n))
                : Results.NotFound();
});

app.MapPost("/api/v1/notes/", async (BaseNote n, INoteSrv noteSrv) =>
{
    var nt = await noteSrv.AddNoteAsync(new Net6WebApi2.DalCommon.Models.Note(n.text, n.done));
    return Results.Created($"/notes/{nt}", nt);
});

app.Run();
