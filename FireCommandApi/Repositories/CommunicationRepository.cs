using FireCommand.Models;
using FireCommand.Repositories.Interfaces;
using FireCommandApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FireCommandApi.Repositories
{

    public class CommunicationRepository : ICommunicationRepository
    {
        private AppDbContext context;

        public CommunicationRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Channel>> GetChannelsAsync()
        {
            return await this.context.Channels.ToListAsync();
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await this.context.Messages.ToListAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            context.Messages.Add(message);
            await context.SaveChangesAsync();
        }
    }
}