using FireCommandApi.Models;
using FireCommandApi.Models.ViewModels;
using FireCommandApi.Repositories.Interfaces;
using FireCommandApi.Services.Interfaces;

namespace FireCommandApi.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IIncidentRepository incidentRepository;
        private readonly IPersonnelRepository personnelRepository;
        private readonly IEquipmentRepository equipmentRepository;
        private readonly IRiskZoneRepository riskZoneRepository;

        public DashboardService(
            IIncidentRepository incidentRepository,
            IPersonnelRepository personnelRepository,
            IEquipmentRepository equipmentRepository,
            IRiskZoneRepository riskZoneRepository)
        {
            this.incidentRepository = incidentRepository;
            this.personnelRepository = personnelRepository;
            this.equipmentRepository = equipmentRepository;
            this.riskZoneRepository = riskZoneRepository;
        }

        public async Task<DashboardViewModel> GetDashboardInfoAsync()
        {
            List<IncidentType> incidentTypes = await this.incidentRepository.GetIncidentTypesAsync();
            List<Priority> priorities = await this.incidentRepository.GetPrioritiesAsync();
            List<Incident> incidents = await this.incidentRepository.GetIncidentsAsync();
            List<Personnel> personnel = await this.personnelRepository.GetPersonnelAsync();
            List<Equipment> equipments = await this.equipmentRepository.GetEquipmentsAsync();
            List<RiskZone> riskZones = await this.riskZoneRepository.GetRiskZonesAsync();

            return new DashboardViewModel
            {
                IncidentTypes = incidentTypes,
                Priorities = priorities,
                Incidents = incidents,
                Personnel = personnel,
                Equipments = equipments,
                RiskZones = riskZones
            };
        }
    }
}
