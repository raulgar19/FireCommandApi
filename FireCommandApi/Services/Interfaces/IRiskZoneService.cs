using FireCommandApi.Models;

namespace FireCommandApi.Services.Interfaces
{
    public interface IRiskZoneService
    {
        Task<List<RiskZone>> GetRiskZonesAsync();

        Task AddRiskZoneAsync(RiskZone riskZone);
        Task DeleteRiskZoneAsync(int id);
    }
}
