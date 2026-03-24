using FireCommand.Models;

namespace FireCommand.Repositories.Interfaces
{
    public interface IPersonnelRepository
    {
        Task<List<Personnel>> GetPersonnelAsync();
        Task<List<Rank>> GetRanksAsync();
        Task<List<Specialization>> GetSpecializationsAsync();
        Task<List<Station>> GetStationsAsync();
        Task<List<PersonnelStatus>> GetPersonnelStatusesAsync();
        Task AddPersonnelAsync(Personnel person);
        Task UpdatePersonnelAsync(Personnel person);
        Task DeletePersonnelAsync(Personnel person);
    }
}
