using Microsoft.EntityFrameworkCore;
using Shared.Data;
using SharedKernel.Common.Api;
using VehicleService.Api.Interfaces;
using VehicleService.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.AddCrossOrigin();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));


builder.Services.AddTransient<IVehicleService, VehicleService.Api.Interfaces.VehicleService>();
builder.Services.AddScoped<IEventPublisher, EventPublisher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

