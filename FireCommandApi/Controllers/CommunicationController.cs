using FireCommandModels.Models;
using FireCommandModels.Models.ViewModels;
using FireCommandModels.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationService communicationService;

        public CommunicationController(ICommunicationService communicationService)
        {
            this.communicationService = communicationService;
        }

        [HttpGet]
        public async Task<ActionResult<CommunicationViewModel>> GetCommunicationsInfoAsync()
        {
            CommunicationViewModel viewModel = await this.communicationService.GetCommunicationsInfoAsync();
            return viewModel;
        }

        [HttpPost]
        public async Task<ActionResult> SendMessage(Message message)
        {
            if (message == null || string.IsNullOrEmpty(message.Content) || message.ChannelId <= 0)
            {
                return BadRequest("Invalid message data.");
            }

            await this.communicationService.AddMessageAsync(message);

            return Ok();
        }
    }
}
