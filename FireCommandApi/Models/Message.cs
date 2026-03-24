using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireCommand.Models
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        [Column("Id")] 
        public int Id { get; set; }

        [Column("Content")] 
        public string Content { get; set; }

        [Column("SentAt")] 
        public DateTime SentAt { get; set; }

        [Column("ChannelId")] 
        public int ChannelId { get; set; }
    }
}