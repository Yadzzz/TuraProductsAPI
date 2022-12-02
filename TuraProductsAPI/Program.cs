using TuraProductsAPI;
using DataAccessLibrary.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//IConfigurationRoot configuration = new ConfigurationBuilder()
//                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//                    .AddJsonFile("appsettings.json")
//                    .Build();

//configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TIDataDbContext>();

Log.Logger = new LoggerConfiguration()
.Enrich.FromLogContext()
.WriteTo.File(@"logs/log.txt", shared: true)
.CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

var app = builder.Build();

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
