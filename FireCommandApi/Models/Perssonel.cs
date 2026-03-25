using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireCommandApi.Models
{
    [Table("Personnel")]
    public class Personnel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("FullName")]
        public string FullName { get; set; }

        [Column("BadgeNumber")]
        public string BadgeNumber { get; set; }

        [Column("RankId")]
        public int RankId { get; set; }

        [Column("SpecializationId")]
        public int SpecializationId { get; set; }

        [Column("AssignedStationId")]
        public int? AssignedStationId { get; set; }

        [Column("StatusId")]
        public int StatusId { get; set; }

        [Column("Phone")]
        public string? Phone { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("JoinDate")]
        public DateTime? JoinDate { get; set; }
    }
}