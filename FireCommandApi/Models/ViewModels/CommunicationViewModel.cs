using FireCommandApi.Models;

namespace FireCommandApi.Models.ViewModels
{
    public class CommunicationViewModel
    {
        public List<Channel> Channels { get; set; }
        public List<Message> Messages { get; set; }
    }
}