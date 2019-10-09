﻿using System.ComponentModel;
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

        [DefaultValue(typeof(TrackStyle), "None")]
        public TrackStyle? Style { get; set; }

        //public int ArtistID { get; set; }

        //[ForeignKey(nameof(ArtistID))]
        public virtual Artist Artist { get; set; }
    }

    public enum TrackStyle : byte
    {
        None, Pop, Reggi, Rock, Metal, Classic
    }
}