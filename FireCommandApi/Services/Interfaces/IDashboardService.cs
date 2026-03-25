using FireCommandApi.Models.ViewModels;

namespace FireCommandApi.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboardInfoAsync();
    }
}
