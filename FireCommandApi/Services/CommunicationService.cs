using FireCommandApi.Models;
using FireCommandApi.Models.ViewModels;
using FireCommandApi.Repositories.Interfaces;
using FireCommandApi.Services.Interfaces;

namespace FireCommandApi.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly ICommunicationRepository communicationRepository;

        public CommunicationService(ICommunicationRepository communicationRepository)
        {
            this.communicationRepository = communicationRepository;
        }

        public async Task<CommunicationViewModel> GetCommunicationsAsync()
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
