using MediatR;
using Rebtel.DeveloperTest.API.Logger;
using Rebtel.DeveloperTest.BLL;
using Rebtel.DeveloperTest.SL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

DbContextFactory dbContextFactory = new DbContextFactory();
dbContextFactory.CreateContext(builder.Services);
builder.Services.AddSingleton<IBookLogic, BooksLogic>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogMessage, ConsoleLogger>();
builder.Services.AddMediatR(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
