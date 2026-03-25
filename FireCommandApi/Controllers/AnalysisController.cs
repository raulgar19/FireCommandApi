using FireCommandApi.Models.ViewModels;
using FireCommandApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IIncidentService incidentService;

        public AnalysisController(IIncidentService incidentService)
        {
            this.incidentService = incidentService;
        }

        [HttpGet]
        public async Task<ActionResult<AnalysisViewModel>> GetAnalysis()
        {
            AnalysisViewModel viewModel = await this.incidentService.GetAnalysisAsync();
            return viewModel;
        }
    }
}