using FireCommandApi.Models;

namespace FireCommandApi.Models.ViewModels
{
    public class IncidentViewModel
    {
        public List<Incident> Incidents { get; set; }
        public List<IncidentType> IncidentTypes { get; set; }
        public List<Priority> Priorities { get; set; }
    }
}