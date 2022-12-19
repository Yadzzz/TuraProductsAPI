using TuraProductsAPI;
using DataAccessLibrary.Context;
using Serilog;
using TuraProductsAPI.Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TIDataDbContext>();
builder.Services.AddScoped<PdfService>();
builder.Services.AddScoped<ParcelService>();
builder.Services.AddScoped<InvoiceService>();

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

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
