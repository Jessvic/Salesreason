using Microsoft.Extensions.Configuration;
using SalesReason.Data;
using SalesReason.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddScoped<SalesReasonRepository>(provider => new SalesReasonRepository(Configuration.GetConnectionString("AdventureWorks")));
    services.AddScoped<SalesReasonService>();
    // ...
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
