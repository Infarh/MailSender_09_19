using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailSender.ConsoleTest.Data
{
    [Table("Track")]
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Length { get; set; }
    }
}