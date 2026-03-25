using FireCommandApi.Models;

namespace FireCommandApi.Models.ViewModels
{
    public class DashboardViewModel
    {
        public List<IncidentType> IncidentTypes { get; set; }
        public List<Priority> Priorities { get; set; }
        public List<Incident> Incidents { get; set; }
        public List<Personnel> Personnel { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<RiskZone> RiskZones { get; set; }
    }
}