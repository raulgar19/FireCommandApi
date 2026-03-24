using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireCommand.Models
{
    [Table("Priorities")]
    public class Priority
    {
        [Key]
        [Column("Id")] 
        public int Id { get; set; }

        [Column("Name")] 
        public string Name { get; set; }
    }
}