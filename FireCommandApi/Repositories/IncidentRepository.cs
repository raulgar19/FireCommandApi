using FireCommand.Models;
using FireCommand.Repositories.Interfaces;
using FireCommandApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FireCommand.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly AppDbContext context;

        public IncidentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Incident>> GetIncidentsAsync()
        {
            return await this.context.Incidents.ToListAsync();
        }

        public async Task<List<Priority>> GetPrioritiesAsync()
        {
            return await this.context.Priorities.ToListAsync();
        }

        public async Task<List<IncidentType>> GetIncidentTypesAsync()
        {
            return await this.context.IncidentTypes.ToListAsync();
        }

        public async Task<Incident> GetIncidentByIdAsync(int id)
        {
            return await this.context.Incidents.FindAsync(id);
        }

        public async Task AddIncidentAsync(Incident incident)
        {
            this.context.Incidents.Add(incident);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateIncidentAsync(Incident incident)
        {
            this.context.Incidents.Update(incident);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteIncidentAsync(int id)
        {
            Incident incident = await this.GetIncidentByIdAsync(id);

            this.context.Incidents.Remove(incident);
            await this.context.SaveChangesAsync();
        }
    }
}