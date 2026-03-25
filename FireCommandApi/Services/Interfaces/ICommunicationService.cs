using FireCommandApi.Models;
using FireCommandApi.Models.ViewModels;

namespace FireCommandApi.Services.Interfaces
{
    public interface ICommunicationService
    {
        Task<CommunicationViewModel> GetCommunicationsAsync();
        Task AddMessageAsync(Message message);
    }
}
