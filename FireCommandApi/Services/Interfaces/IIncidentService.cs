using FireCommandApi.Models;
using FireCommandApi.Models.ViewModels;

namespace FireCommandApi.Services.Interfaces
{
    public interface IIncidentService
    {
        Task<IncidentViewModel> GetIncidentOverviewAsync();
        Task<AnalysisViewModel> GetAnalysisAsync();

        Task<List<Incident>> GetIncidentsAsync();
        Task<List<Priority>> GetPrioritiesAsync();
        Task<List<IncidentType>> GetIncidentTypesAsync();

        Task AddIncidentAsync(Incident incident);
        Task UpdateIncidentAsync(Incident incident);
        Task DeleteIncidentAsync(int id);
    }
}
