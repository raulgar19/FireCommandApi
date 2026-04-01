using FireCommandModels.Models;
using FireCommandModels.Models.ViewModels;
using FireCommandModels.Repositories.Interfaces;
using FireCommandModels.Services.Interfaces;

namespace FireCommandApi.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository incidentRepository;

        public IncidentService(IIncidentRepository incidentRepository)
        {
            this.incidentRepository = incidentRepository;
        }

        public async Task<IncidentViewModel> GetIncidentsInfoAsync()
        {
            List<Incident> incidents = await this.incidentRepository.GetIncidentsAsync();
            List<IncidentType> incidentTypes = await this.incidentRepository.GetIncidentTypesAsync();
            List<Priority> priorities = await this.incidentRepository.GetPrioritiesAsync();

            return new IncidentViewModel
            {
                Incidents = incidents,
                IncidentTypes = incidentTypes,
                Priorities = priorities
            };
        }

        public async Task<AnalysisViewModel> GetAnalysisAsync()
        {
            List<Incident> incidents = await this.incidentRepository.GetIncidentsAsync();
            List<IncidentType> incidentTypes = await this.incidentRepository.GetIncidentTypesAsync();

            return new AnalysisViewModel
            {
                Incidents = incidents,
                IncidentTypes = incidentTypes
            };
        }

        public Task AddIncidentAsync(Incident incident)
        {
            return this.incidentRepository.AddIncidentAsync(incident);
        }

        public Task UpdateIncidentAsync(Incident incident)
        {
            return this.incidentRepository.UpdateIncidentAsync(incident);
        }

        public async Task DeleteIncidentAsync(int id)
        {
            Incident incident = await this.incidentRepository.FindIncidentAsync(id);

            if (incident == null)
            {
                return;
            }

            await this.incidentRepository.DeleteIncidentAsync(incident);
        }
    }
}