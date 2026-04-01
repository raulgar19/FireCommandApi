using FireCommandModels.Models;
using FireCommandModels.Models.ViewModels;
using FireCommandModels.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<ActionResult<EquipmentViewModel>> GetEquipmentInfoAsync()
        {
            EquipmentViewModel viewModel = await this.equipmentService.GetEquipmentInfoAsync();
            return viewModel;
        }

        [HttpPost]
        public async Task<ActionResult> AddEquipment(Equipment equipment)
        {
            await this.equipmentService.AddEquipmentAsync(equipment);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEquipment(Equipment equipment)
        {
            await this.equipmentService.UpdateEquipmentAsync(equipment);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEquipment(int id)
        {
            await this.equipmentService.DeleteEquipmentAsync(id);
            return Ok();
        }
    }
}