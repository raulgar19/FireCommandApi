using FireCommandApi.Services.Interfaces;
using FireCommandModels.Models;
using FireCommandModels.Models.ViewModels;
using FireCommandModels.Repositories.Interfaces;

namespace FireCommandApi.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            this.equipmentRepository = equipmentRepository;
        }

        public async Task<EquipmentViewModel> GetEquipmentOverviewAsync()
        {
            List<Equipment> equipments = await this.equipmentRepository.GetEquipmentsAsync();
            List<EquipmentType> equipmentTypes = await this.equipmentRepository.GetEquipmentTypesAsync();
            List<EquipmentStatus> equipmentStatuses = await this.equipmentRepository.GetEquipmentStatusesAsync();
            List<EquipmentCondition> equipmentConditions = await this.equipmentRepository.GetEquipmentConditionsAsync();
            List<Station> stations = await this.equipmentRepository.GetStationsAsync();

            return new EquipmentViewModel
            {
                Equipments = equipments,
                EquipmentTypes = equipmentTypes,
                EquipmentStatuses = equipmentStatuses,
                EquipmentConditions = equipmentConditions,
                Stations = stations
            };
        }

        public Task AddEquipmentAsync(Equipment equipment)
        {
            return this.equipmentRepository.AddEquipmentAsync(equipment);
        }

        public Task UpdateEquipmentAsync(Equipment equipment)
        {
            return this.equipmentRepository.UpdateEquipmentAsync(equipment);
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            Equipment equipment = await this.equipmentRepository.FindEquipmentAsync(id);

            if (equipment == null)
            {
                return;
            }

            await this.equipmentRepository.DeleteEquipmentAsync(equipment);
        }
    }
}