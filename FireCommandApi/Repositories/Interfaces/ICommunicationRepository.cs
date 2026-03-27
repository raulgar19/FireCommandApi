using FireCommandModels.Models;

namespace FireCommandApi.Repositories.Interfaces
{
    public interface ICommunicationRepository
    {
        Task<List<Channel>> GetChannelsAsync();
        Task<List<Message>> GetMessagesAsync();
        Task AddMessageAsync(Message message);
    }
}