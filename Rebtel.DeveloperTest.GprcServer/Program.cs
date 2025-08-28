using Rebtel.DeveloperTest.BLL;
using Rebtel.DeveloperTest.GprcServer.Services;
using Rebtel.DeveloperTest.SL;
using Rebtel.DeveloperTest.SL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

DbContextFactory dbContextFactory = new DbContextFactory();
dbContextFactory.RegisterDBContext(builder.Services);
builder.Services.AddGrpc();
builder.Services.AddSingleton<IBookLogic, BooksLogic>();
builder.Services.AddSingleton<IBorrowerLogic, BorrowerLogic>();

var app = builder.Build();



// Configure the HTTP request pipeline.

app.MapGrpcService<BookService>();
app.MapGrpcService<BorrowerService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
