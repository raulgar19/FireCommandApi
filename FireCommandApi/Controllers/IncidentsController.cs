using FireCommandModels.Models;
using FireCommandModels.Models.ViewModels;
using FireCommandApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            this.incidentService = incidentService;
        }

        [HttpGet]
        public async Task<ActionResult<IncidentViewModel>> GetIncidents()
        {
            IncidentViewModel viewModel = await this.incidentService.GetIncidentOverviewAsync();
            return viewModel;
        }

        [HttpPost]
        public async Task<ActionResult> CreateIncident(Incident incident)
        {
            await this.incidentService.AddIncidentAsync(incident);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateIncident(Incident incident)
        {
            await this.incidentService.UpdateIncidentAsync(incident);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteIncident(int id)
        {
            await this.incidentService.DeleteIncidentAsync(id);
            return Ok();
        }
    }
}