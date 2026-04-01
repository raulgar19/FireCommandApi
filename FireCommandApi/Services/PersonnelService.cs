using FireCommandModels.Models;
using FireCommandModels.Models.ViewModels;
using FireCommandModels.Repositories.Interfaces;
using FireCommandModels.Services.Interfaces;

namespace FireCommandApi.Services
{
    public class PersonnelService : IPersonnelService
    {
        private readonly IPersonnelRepository personnelRepository;

        public PersonnelService(IPersonnelRepository personnelRepository)
        {
            this.personnelRepository = personnelRepository;
        }

        public async Task<PersonnelViewModel> GetPersonnelInfoAsync()
        {
            List<Personnel> personnel = await this.personnelRepository.GetPersonnelAsync();
            List<Rank> ranks = await this.personnelRepository.GetRanksAsync();
            List<Specialization> specializations = await this.personnelRepository.GetSpecializationsAsync();
            List<Station> stations = await this.personnelRepository.GetStationsAsync();
            List<PersonnelStatus> personnelStatuses = await this.personnelRepository.GetPersonnelStatusesAsync();

            return new PersonnelViewModel
            {
                Personnel = personnel,
                Ranks = ranks,
                Specializations = specializations,
                Stations = stations,
                PersonnelStatuses = personnelStatuses
            };
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
