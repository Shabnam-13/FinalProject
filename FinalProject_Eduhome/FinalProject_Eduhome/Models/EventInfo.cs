using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class EventInfo
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public int SpeakerId { get; set; }

        public Speakers Speaker { get; set; }
    }
}