using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireCommandApi.Models
{
    [Table("Equipment")]
    public class Equipment
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("SerialNumber")]
        public string SerialNumber { get; set; }

        [Column("TypeId")]
        public int TypeId { get; set; }

        [Column("StatusId")]
        public int StatusId { get; set; }

        [Column("ConditionId")]
        public int ConditionId { get; set; }

        [Column("StationId")]
        public int? StationId { get; set; }

        [Column("LastMaintenance")]
        public DateTime? LastMaintenance { get; set; }

        [Column("NextMaintenance")]
        public DateTime? NextMaintenance { get; set; }

        [Column("Notes")]
        public string? Notes { get; set; }
    }
}