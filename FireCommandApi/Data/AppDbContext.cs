using FireCommandApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FireCommandApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentType> IncidentTypes { get; set; }
        public DbSet<IncidentStatus> IncidentStatuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<PersonnelStatus> PersonnelStatuses { get; set; }

        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<EquipmentStatus> EquipmentStatuses { get; set; }
        public DbSet<EquipmentCondition> EquipmentConditions { get; set; }

        public DbSet<Station> Stations { get; set; }
        public DbSet<RiskZone> RiskZones { get; set; }
        public DbSet<RiskType> RiskTypes { get; set; }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
