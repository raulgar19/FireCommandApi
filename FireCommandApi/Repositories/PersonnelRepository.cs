using FireCommand.Models;
using FireCommand.Repositories.Interfaces;
using FireCommandApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FireCommand.Repositories
{
    public class PersonnelRepository : IPersonnelRepository
    {
        private AppDbContext context;

        public PersonnelRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Personnel>> GetPersonnelAsync()
        {
            return await this.context.Personnel.ToListAsync();
        }

        public async Task<List<Rank>> GetRanksAsync()
        {
            return await this.context.Ranks.ToListAsync();
        }

        public async Task<List<Specialization>> GetSpecializationsAsync()
        {
            return await this.context.Specializations.ToListAsync();
        }

        public async Task<List<Station>> GetStationsAsync()
        {
            return await this.context.Stations.ToListAsync();
        }

        public async Task<List<PersonnelStatus>> GetPersonnelStatusesAsync()
        {
            return await this.context.PersonnelStatuses.ToListAsync();
        }

        public async Task AddPersonnelAsync(Personnel person)
        {
            this.context.Personnel.Add(person);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonnelAsync(Personnel person)
        {
            this.context.Personnel.Update(person);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonnelAsync(Personnel person)
        {
            this.context.Personnel.Remove(person);
            await this.context.SaveChangesAsync();
        }
    }
}