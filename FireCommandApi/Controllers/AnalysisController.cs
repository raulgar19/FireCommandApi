using FireCommand.Models;
using FireCommand.Models.ViewModels;
using FireCommand.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private IIncidentRepository incidentRepository;

        public AnalysisController(IIncidentRepository incidentRepository)
        {
            this.incidentRepository = incidentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<AnalysisViewModel>> GetAnalysis()
        {
            List<Incident> incidents = await incidentRepository.GetIncidentsAsync();
            List<IncidentType> incidentTypes = await incidentRepository.GetIncidentTypesAsync();

            AnalysisViewModel viewModel = new AnalysisViewModel
            {
                Incidents = incidents,
                IncidentTypes = incidentTypes
            };

            return viewModel;
        }
    }
}