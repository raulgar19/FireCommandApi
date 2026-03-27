using FireCommandModels.Models;

namespace FireCommandApi.Repositories.Interfaces
{
    public interface IIncidentRepository
    {
        Task<List<Incident>> GetIncidentsAsync();
        Task<List<Priority>> GetPrioritiesAsync();
        Task<List<IncidentType>> GetIncidentTypesAsync();
        Task<Incident> FindIncidentAsync(int id);
        Task AddIncidentAsync(Incident incident);
        Task UpdateIncidentAsync(Incident incident);
        Task DeleteIncidentAsync(Incident incident);
    }
}