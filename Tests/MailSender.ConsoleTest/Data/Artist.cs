using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailSender.ConsoleTest.Data
{
    public class Artist
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}