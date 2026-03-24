using FireCommand.Models;

namespace FireCommand.Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<List<Equipment>> GetEquipmentsAsync();
        Task<List<EquipmentCondition>> GetEquipmentConditionsAsync();
        Task<List<EquipmentStatus>> GetEquipmentStatusesAsync();
        Task<List<EquipmentType>> GetEquipmentTypesAsync();
        Task<List<Station>> GetStationsAsync();
        Task AddEquipmentAsync(Equipment equipment);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(Equipment equipment);
    }
}