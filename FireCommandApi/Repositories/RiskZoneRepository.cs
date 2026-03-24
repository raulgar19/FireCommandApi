using FireCommand.Models;
using FireCommand.Repositories.Interfaces;
using FireCommandApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FireCommand.Repositories
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

        public async Task DeleteRiskZoneAsync(int id)
        {
            var zone = await this.context.RiskZones.FindAsync(id);
            if (zone != null)
            {
                this.context.RiskZones.Remove(zone);
                await this.context.SaveChangesAsync();
            }
        }
    }
}