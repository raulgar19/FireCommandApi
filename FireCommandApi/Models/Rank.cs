using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireCommand.Models
{
    [Table("Ranks")]
    public class Rank
    {
        [Key]
        [Column("Id")] 
        public int Id { get; set; }

        [Column("Name")] 
        public string Name { get; set; }
    }
}