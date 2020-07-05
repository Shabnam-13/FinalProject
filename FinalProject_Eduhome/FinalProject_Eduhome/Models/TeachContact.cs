using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class TeachContact
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Mail { get; set; }

        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Skype { get; set; }

        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        public Teachers Teacher { get; set; }
    }
}