using FireCommand.Models;

namespace FireCommand.Repositories.Interfaces
{
    public interface ICommunicationRepository
    {
        Task<List<Channel>> GetChannelsAsync();
        Task<List<Message>> GetMessagesAsync();
        Task AddMessageAsync(Message message);
    }
}