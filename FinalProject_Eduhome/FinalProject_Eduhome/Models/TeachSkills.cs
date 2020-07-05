using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class TeachSkills
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(5)]
        [Required]
        public string Progress { get; set; }

        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        public Teachers Teacher { get; set; }
    }
}