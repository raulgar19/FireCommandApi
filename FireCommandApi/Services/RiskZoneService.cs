using FireCommandModels.Models;
using FireCommandModels.Models.ViewModels;
using FireCommandModels.Repositories.Interfaces;
using FireCommandModels.Services.Interfaces;

namespace FireCommandApi.Services
{
    public class RiskZoneService : IRiskZoneService
    {
        private IRiskZoneRepository riskZoneRepository;
        private IIncidentRepository incidentRepository;

        public RiskZoneService(IRiskZoneRepository riskZoneRepository, IIncidentRepository incidentRepository)
        {
            this.riskZoneRepository = riskZoneRepository;
            this.incidentRepository = incidentRepository;
        }

        public async Task<RiskZoneViewModel> GetRiskZonesInfoAsync()
        {
            List<RiskZone> riskZones = await this.riskZoneRepository.GetRiskZonesAsync();
            List<Priority> priorioties = await this.incidentRepository.GetPrioritiesAsync();
            List<RiskType> riskTypes = await this.riskZoneRepository.GetRiskTypesAsync();
            List<Station> stations = await this.riskZoneRepository.GetStationsAsync();

            return new RiskZoneViewModel
            {
                RiskZones = riskZones,
                Priorioties = priorioties,
                RiskTypes = riskTypes,
                Stations = stations
            };
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