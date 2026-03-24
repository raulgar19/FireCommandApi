using FireCommand.Models;

namespace FireCommand.Repositories.Interfaces
{
    public interface IIncidentRepository
    {
        Task<List<Incident>> GetIncidentsAsync();
        Task<List<Priority>> GetPrioritiesAsync();
        Task<List<IncidentType>> GetIncidentTypesAsync();
        Task AddIncidentAsync(Incident incident);
        Task UpdateIncidentAsync(Incident incident);
        Task DeleteIncidentAsync(int id);
    }
}