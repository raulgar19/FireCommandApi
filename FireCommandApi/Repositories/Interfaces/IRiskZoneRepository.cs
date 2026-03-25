using FireCommandApi.Models;

namespace FireCommandApi.Repositories.Interfaces
{
    public interface IRiskZoneRepository
    {
        Task<List<RiskZone>> GetRiskZonesAsync();
        Task<RiskZone> FindRiskZoneAsync(int id);
        Task<List<RiskType>> GetRiskTypesAsync();
        Task<List<Station>> GetStationsAsync();
        Task AddRiskZoneAsync(RiskZone riskZone);
        Task DeleteRiskZoneAsync(RiskZone riskZone);
    }
}