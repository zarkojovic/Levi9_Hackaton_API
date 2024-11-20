using DataAccess;
using HackatonLeviNine.Core;
using ProjectASP.API.Core;
using ProjectASP.Application;
using ProjectASP.Implementation;
using ProjectASP.Implementation.Logging.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<AspContext>();
builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();

// Registering All Use Cases Dependencies from Extention Method
builder.Services.AddUseCases();
builder.Services.AddTransient<AspContext>();

builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();


// Trying to access Actor from the HttpContext if it exists, if not, return UnauthorizedActor
builder.Services.AddTransient<IApplicationActor>(x =>
{
    return new UnauthorizedActor(); 
});


var app = builder.Build();

// Registering Global Exception Handling Middleware
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
