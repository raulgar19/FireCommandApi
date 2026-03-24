namespace FireCommand.Models.ViewModels
{
    public class EquipmentViewModel
    {
        public List<Equipment> Equipments { get; set; }
        public List<EquipmentType> EquipmentTypes { get; set; }
        public List<EquipmentStatus> EquipmentStatuses { get; set; }
        public List<EquipmentCondition> EquipmentConditions { get; set; }
        public List<Station> Stations { get; set; }
    }
}