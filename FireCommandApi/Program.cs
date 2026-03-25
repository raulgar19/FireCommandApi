using FireCommandApi.Repositories;
using FireCommandApi.Repositories.Interfaces;
using FireCommandApi.Services;
using FireCommandApi.Services.Interfaces;
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

builder.Services.AddTransient<IIncidentService, IncidentService>();
builder.Services.AddTransient<IEquipmentService, EquipmentService>();
builder.Services.AddTransient<IPersonnelService, PersonnelService>();
builder.Services.AddTransient<IRiskZoneService, RiskZoneService>();
builder.Services.AddTransient<ICommunicationService, CommunicationService>();
builder.Services.AddTransient<IDashboardService, DashboardService>();

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
