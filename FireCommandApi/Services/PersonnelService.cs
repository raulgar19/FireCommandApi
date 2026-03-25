using FireCommandApi.Models;
using FireCommandApi.Repositories.Interfaces;
using FireCommandApi.Services.Interfaces;

namespace FireCommandApi.Services
{
    public class PersonnelService : IPersonnelService
    {
        private readonly IPersonnelRepository personnelRepository;

        public PersonnelService(IPersonnelRepository personnelRepository)
        {
            this.personnelRepository = personnelRepository;
        }

        public Task<List<Personnel>> GetPersonnelAsync()
        {
            return this.personnelRepository.GetPersonnelAsync();
        }

        public Task AddPersonnelAsync(Personnel personnel)
        {
            return this.personnelRepository.AddPersonnelAsync(personnel);
        }

        public Task UpdatePersonnelAsync(Personnel personnel)
        {
            return this.personnelRepository.UpdatePersonnelAsync(personnel);
        }

        public async Task DeletePersonnelAsync(int id)
        {
            Personnel person = await this.personnelRepository.FindPersonnelAsync(id);

            if (person == null)
            {
                return;
            }

            await this.personnelRepository.DeletePersonnelAsync(person);
        }
    }
}
