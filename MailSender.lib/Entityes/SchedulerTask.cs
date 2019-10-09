using System;
using System.ComponentModel.DataAnnotations;
using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    public class SchedulerTask : BaseEntity
    {
        public DateTime Time { get; set; }

        [Required]
        public Server Server { get; set; }

        [Required]
        public Sender Sender { get; set; }

        [Required]
        public RecipientsList Recipients { get; set; }

        [Required]
        public Email Email { get; set; }
    }
}