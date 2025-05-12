var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.MapGet("/shirts", () =>
//{
//    return "reading all the shirts";

//});

//app.MapGet("/shirts/{id}",(int id) =>
//{
//    return $"reading shirt with ID:{id}";

//});

//app.MapPost("/shirts", () =>
//{
//    return "Creating a shirt.";
//});

//app.MapPut("/shirts/{id}", (int id) =>
//{
//    return $"Updating shirt with ID: {id}";
//});

//app.MapDelete("/shirts/{id}", (int id) =>
//{
//    return $"Deleting shirt with ID: {id}";
//});
app.MapControllers();

app.Run();

