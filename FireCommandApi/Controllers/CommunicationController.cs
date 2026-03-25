using FireCommandApi.Models;
using FireCommandApi.Models.ViewModels;
using FireCommandApi.Services.Interfaces;
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
        public async Task<ActionResult<CommunicationViewModel>> GetCommunications()
        {
            CommunicationViewModel viewModel = await this.communicationService.GetCommunicationsAsync();
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
