using System.ComponentModel.DataAnnotations;

namespace MailSender.lib.Entityes.Base
{
    public abstract class HumanEntity : NamedEntity
    {
        [Required]
        public virtual string Address { get; set; }
    }
}