using FireCommandModels.Models;
using FireCommandModels.Models.ViewModels;
using FireCommandModels.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : ControllerBase
    {
        private readonly IPersonnelService personnelService;

        public PersonnelController(IPersonnelService personnelService)
        {
            this.personnelService = personnelService;
        }

        [HttpGet]
        public async Task<ActionResult<PersonnelViewModel>> GetPersonnelInfoAsync()
        {
            PersonnelViewModel personnel = await this.personnelService.GetPersonnelInfoAsync();

            return personnel;
        }

        [HttpPost]
        public async Task<ActionResult> AddPersonnel(Personnel personnel)
        {
            await this.personnelService.AddPersonnelAsync(personnel);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonnel(Personnel personnel)
        {
            await this.personnelService.UpdatePersonnelAsync(personnel);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePersonnel(int id)
        {
            await this.personnelService.DeletePersonnelAsync(id);
            return Ok();
        }
    }
}