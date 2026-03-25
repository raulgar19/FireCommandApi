using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireCommandApi.Models
{
    [Table("EquipmentTypes")]
    public class EquipmentType
    {
        [Key][Column("Id")] public int Id { get; set; }
        [Column("Name")] public string Name { get; set; }
    }
}