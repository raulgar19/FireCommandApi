using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireCommand.Models
{
    [Table("RiskZones")]
    public class RiskZone
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("RiskLevelId")]
        public int RiskLevelId { get; set; }

        [Column("RiskTypeId")]
        public int RiskTypeId { get; set; }

        [Column("Address")]
        public string? Address { get; set; }

        [Column("Latitude")]
        public double Latitude { get; set; }

        [Column("Longitude")]
        public double Longitude { get; set; }

        [Column("Radius")]
        public int Radius { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("Recommendations")]
        public string? Recommendations { get; set; }
    }
}