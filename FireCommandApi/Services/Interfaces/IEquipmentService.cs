using FireCommandApi.Models;
using FireCommandApi.Models.ViewModels;

namespace FireCommandApi.Services.Interfaces
{
    public interface IEquipmentService
    {
        Task<EquipmentViewModel> GetEquipmentOverviewAsync();

        Task AddEquipmentAsync(Equipment equipment);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(int id);
    }
}
