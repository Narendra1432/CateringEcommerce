using CateringEcommerce.Domain.Interfaces;
using CateringEcommerce.BAL.DatabaseHelper;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register service
builder.Services.AddSingleton<IDatabaseHelper>(new DatabaseHelper(connectionString));

app.MapGet("/", () => "Hello World!");

app.Run();
