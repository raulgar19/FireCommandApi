using FireCommand.Models;
using FireCommand.Models.ViewModels;
using FireCommand.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private IIncidentRepository incidentRepository;

        public IncidentsController(IIncidentRepository repository)
        {
            this.incidentRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IncidentViewModel>> GetIncidents()
        {
            List<Incident> incidents = await this.incidentRepository.GetIncidentsAsync();
            List<IncidentType> incidentTypes = await this.incidentRepository.GetIncidentTypesAsync();
            List<Priority> priorities = await this.incidentRepository.GetPrioritiesAsync();

            IncidentViewModel viewModel = new IncidentViewModel
            {
                Incidents = incidents,
                IncidentTypes = incidentTypes,
                Priorities = priorities
            };

            return viewModel;
        }

        [HttpPost]
        public async Task<ActionResult> CreateIncident(Incident incident)
        {
            await this.incidentRepository.AddIncidentAsync(incident);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateIncident(Incident incident)
        {
            await this.incidentRepository.UpdateIncidentAsync(incident);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteIncident(int id)
        {
            await this.incidentRepository.DeleteIncidentAsync(id);
            return Ok();
        }
    }
}