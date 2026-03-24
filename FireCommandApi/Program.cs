using FireCommand.Repositories;
using FireCommand.Repositories.Interfaces;
using FireCommandApi.Data;
using FireCommandApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IIncidentRepository, IncidentRepository>();
builder.Services.AddTransient<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddTransient<IPersonnelRepository, PersonnelRepository>();
builder.Services.AddTransient<ICommunicationRepository, CommunicationRepository>();
builder.Services.AddTransient<IRiskZoneRepository, RiskZoneRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FireCommand")));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
