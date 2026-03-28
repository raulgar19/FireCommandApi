using FireCommandApi.Data;
using FireCommandModels.Models;
using FireCommandModels.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FireCommandApi.Repositories
{
    public class RiskZoneRepository : IRiskZoneRepository
    {
        private AppDbContext context;

        public RiskZoneRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<RiskZone>> GetRiskZonesAsync()
        {
            return await this.context.RiskZones.ToListAsync();
        }

        public async Task<RiskZone> FindRiskZoneAsync(int id)
        {
            return await this.context.RiskZones.FindAsync(id);
        }

        public async Task<List<RiskType>> GetRiskTypesAsync()
        {
            return await this.context.RiskTypes.ToListAsync();
        }

        public async Task<List<Station>> GetStationsAsync()
        {
            return await this.context.Stations.ToListAsync();
        }

        public async Task AddRiskZoneAsync(RiskZone riskZone)
        {
            await this.context.RiskZones.AddAsync(riskZone);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteRiskZoneAsync(RiskZone riskZone)
        {
            this.context.RiskZones.Remove(riskZone);
            await this.context.SaveChangesAsync();
        }
    }
}