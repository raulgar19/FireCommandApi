using FireCommandModels.Models;
using FireCommandApi.Repositories.Interfaces;
using FireCommandApi.Services.Interfaces;

namespace FireCommandApi.Services
{
    public class RiskZoneService : IRiskZoneService
    {
        private readonly IRiskZoneRepository riskZoneRepository;

        public RiskZoneService(IRiskZoneRepository riskZoneRepository)
        {
            this.riskZoneRepository = riskZoneRepository;
        }

        public Task<List<RiskZone>> GetRiskZonesAsync()
        {
            return this.riskZoneRepository.GetRiskZonesAsync();
        }

        public Task AddRiskZoneAsync(RiskZone riskZone)
        {
            return this.riskZoneRepository.AddRiskZoneAsync(riskZone);
        }

        public async Task DeleteRiskZoneAsync(int id)
        {
            RiskZone riskZone = await this.riskZoneRepository.FindRiskZoneAsync(id);

            if (riskZone == null)
            {
                return;
            }

            await this.riskZoneRepository.DeleteRiskZoneAsync(riskZone);
        }
    }
}
