using FireCommandApi.Services.Interfaces;
using FireCommandModels.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<ActionResult<DashboardViewModel>> GetDashboardInfo()
        {
            DashboardViewModel dashboardInfo = await this.dashboardService.GetDashboardInfoAsync();
            return dashboardInfo;
        }
    }
}