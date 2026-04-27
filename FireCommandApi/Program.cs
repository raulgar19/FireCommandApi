using Azure.Security.KeyVault.Secrets;
using FireCommandApi.Data;
using FireCommandApi.Repositories;
using FireCommandApi.Services;
using FireCommandModels.Repositories.Interfaces;
using FireCommandModels.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;

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
builder.Services.AddTransient<ITelegramService, TelegramService>();

builder.Services.AddAzureClients(factory =>
{
    factory.AddSecretClient(builder.Configuration.GetSection("KeyVault"));
});

builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var secretClient = serviceProvider.GetRequiredService<SecretClient>();
    KeyVaultSecret secret = secretClient.GetSecret("FireCommandDb");

    options.UseSqlServer(secret.Value);
});

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
