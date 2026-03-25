using FireCommandApi.Models;

namespace FireCommandApi.Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<List<Equipment>> GetEquipmentsAsync();
        Task<Equipment> FindEquipmentAsync(int id);
        Task<List<EquipmentCondition>> GetEquipmentConditionsAsync();
        Task<List<EquipmentStatus>> GetEquipmentStatusesAsync();
        Task<List<EquipmentType>> GetEquipmentTypesAsync();
        Task<List<Station>> GetStationsAsync();
        Task AddEquipmentAsync(Equipment equipment);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(Equipment equipment);
    }
}