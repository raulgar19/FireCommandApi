using FireCommandModels.Models;
using FireCommandModels.Models.ViewModels;
using FireCommandModels.Repositories.Interfaces;
using FireCommandModels.Services.Interfaces;

namespace FireCommandApi.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly ICommunicationRepository communicationRepository;

        public CommunicationService(ICommunicationRepository communicationRepository)
        {
            this.communicationRepository = communicationRepository;
        }

        public async Task<CommunicationViewModel> GetCommunicationsInfoAsync()
        {
            List<Channel> channels = await this.communicationRepository.GetChannelsAsync();
            List<Message> messages = await this.communicationRepository.GetMessagesAsync();

            return new CommunicationViewModel
            {
                Channels = channels,
                Messages = messages
            };
        }

        public Task AddMessageAsync(Message message)
        {
            return this.communicationRepository.AddMessageAsync(message);
        }
    }
}
