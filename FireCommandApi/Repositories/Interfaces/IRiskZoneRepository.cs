using FireCommand.Models;

namespace FireCommand.Repositories.Interfaces
{
    public interface IRiskZoneRepository
    {
        Task<List<RiskZone>> GetRiskZonesAsync();
        Task<List<RiskType>> GetRiskTypesAsync();
        Task<List<Station>> GetStationsAsync();
        Task AddRiskZoneAsync(RiskZone riskZone);
        Task DeleteRiskZoneAsync(int id);
    }
}