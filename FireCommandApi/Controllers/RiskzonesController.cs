using FireCommandApi.Models;
using FireCommandApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskzonesController : ControllerBase
    {
        private readonly IRiskZoneService riskZoneService;

        public RiskzonesController(IRiskZoneService riskZoneService)
        {
            this.riskZoneService = riskZoneService;
        }

        [HttpGet]
        public async Task<ActionResult> GetRiskzones()
        {
            var riskzones = await this.riskZoneService.GetRiskZonesAsync();
            return Ok(riskzones);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRiskzone(RiskZone riskzone)
        {
            if (riskzone == null)
            {
                return BadRequest("RiskZone object is null.");
            }

            await this.riskZoneService.AddRiskZoneAsync(riskzone);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRiskzones(int id)
        {
            await this.riskZoneService.DeleteRiskZoneAsync(id);
            return Ok();
        }
    }
}