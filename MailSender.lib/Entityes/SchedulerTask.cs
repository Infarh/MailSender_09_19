﻿using System;
using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    public class SchedulerTask : BaseEntity
    {
        public DateTime Time { get; set; }

        public Server Server { get; set; }

        public Sender Sender { get; set; }

        public RecipientsList Recipients { get; set; }

        public Email Email { get; set; }
    }
}