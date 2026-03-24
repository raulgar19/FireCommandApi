using FireCommand.Models;
using FireCommand.Repositories.Interfaces;
using FireCommandApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FireCommand.Repositories
{

    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly AppDbContext context;

        public EquipmentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Equipment>> GetEquipmentsAsync()
        {
            return await this.context.Equipment.ToListAsync();
        }

        public async Task<List<EquipmentCondition>> GetEquipmentConditionsAsync()
        {
            return await this.context.EquipmentConditions.ToListAsync();
        }

        public async Task<List<EquipmentStatus>> GetEquipmentStatusesAsync()
        {
            return await this.context.EquipmentStatuses.ToListAsync();
        }

        public async Task<List<EquipmentType>> GetEquipmentTypesAsync()
        {
            return await this.context.EquipmentTypes.ToListAsync();
        }

        public async Task<List<Station>> GetStationsAsync()
        {
            return await this.context.Stations.ToListAsync();
        }

        public async Task AddEquipmentAsync(Equipment equipment)
        {
            this.context.Equipment.Add(equipment);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateEquipmentAsync(Equipment equipment)
        {
            this.context.Update(equipment);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteEquipmentAsync(Equipment equipment)
        {
            this.context.Equipment.Remove(equipment);
            await context.SaveChangesAsync();
        }
    }
}