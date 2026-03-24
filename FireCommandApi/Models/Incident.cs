using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireCommand.Models
{
    [Table("Incidents")]
    public class Incident
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("TypeId")]
        public int TypeId { get; set; }

        [Column("PriorityId")]
        public int PriorityId { get; set; }

        [Column("StatusId")]
        public int StatusId { get; set; }

        [Column("Location")]
        public string Location { get; set; }

        [Column("ReportedBy")]
        public string ReportedBy { get; set; }

        [Column("RegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Column("ContactPhone")]
        public string? ContactPhone { get; set; }

        [Column("Description")]
        public string? Description { get; set; }
    }
}