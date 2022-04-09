//using Microsoft.EntityFrameworkCore;

using Net6WebApi2.DalCommon;
using Net6WebApi2.DalEfImpl;
using Net6WebApi2.DTO;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//// Connect to PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.UseNoteDbContext(connectionString);
//builder.Services.AddDbContext<NoteDb>(options =>
//    options.UseNpgsql(connectionString));

//... rest of the code omitted for brevity
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//... rest of the code omitted for brevity

builder.UseNoteSrv();

WebApplication? app = builder.Build();
//... rest of the code omitted for brevity


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


//app.MapPost("/notes/", async (Note n, NoteDb db) =>
//{
//    db.Notes.Add(n);
//    await db.SaveChangesAsync();
//    return Results.Created($"/notes/{n.id}", n);
//});


//app.MapGet("/notes/{id:int}", async (int id, NoteDb db) =>
//{
//    return await db.Notes.FindAsync(id)
//            is Note n
//                ? Results.Ok(n)
//                : Results.NotFound();
//});


//app.MapGet("/notes", async (NoteDb db) => await db.Notes.ToListAsync());


app.MapPost("/notes/", async (Note n, INoteSrv noteSrv) =>
{
    var nt = await noteSrv.AddNoteAsync(new Net6WebApi2.DalCommon.Models.Note(n.text, n.done));
    return Results.Created($"/notes/{nt}", nt);
});


app.MapGet("/notes/{id:int}", async (int id, INoteSrv noteSrv) =>
{
    return await noteSrv.FindNote(id)
            is Net6WebApi2.DalCommon.Models.Note n
                ? Results.Ok(n)
                : Results.NotFound();
});



app.Run();
