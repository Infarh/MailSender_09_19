using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    public class RecipientsList : NamedEntity
    {
        [Required]
        public ICollection<Recipient> Recipients { get; set; }
    }
}