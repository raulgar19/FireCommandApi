using FireCommand.Models;
using FireCommand.Models.ViewModels;
using FireCommand.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private IIncidentRepository incidentRepository;
        private IPersonnelRepository personnelRepository;
        private IEquipmentRepository equipmentRepository;
        private IRiskZoneRepository riskZoneRepository;

        public DashboardController(IIncidentRepository incidentRepository, IPersonnelRepository personnelRepository, IEquipmentRepository equipmentRepository, IRiskZoneRepository riskZoneRepository)
        {
            this.incidentRepository = incidentRepository;
            this.personnelRepository = personnelRepository;
            this.equipmentRepository = equipmentRepository;
            this.riskZoneRepository = riskZoneRepository;
        }

        [HttpGet]
        public async Task<ActionResult<DashboardViewModel>> GetDashboardInfo()
        {
            List<IncidentType> incidentTypes = await this.incidentRepository.GetIncidentTypesAsync();
            List<Priority> priorities = await this.incidentRepository.GetPrioritiesAsync();
            List<Incident> incidents = await this.incidentRepository.GetIncidentsAsync();
            List<Personnel> personnel = await this.personnelRepository.GetPersonnelAsync();
            List<Equipment> equipments = await this.equipmentRepository.GetEquipmentsAsync();
            List<RiskZone> riskZones = await this.riskZoneRepository.GetRiskZonesAsync();

            DashboardViewModel dashboardInfo = new DashboardViewModel
            {
                IncidentTypes = incidentTypes,
                Priorities = priorities,
                Incidents = incidents,
                Personnel = personnel,
                Equipments = equipments,
                RiskZones = riskZones
            };

            return dashboardInfo;
        }
    }
}