using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class EduContacts
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Address { get; set; }

        [MaxLength(20)]
        [Required]
        public string Phone1 { get; set; }

        [MaxLength(20)]
        public string Phone2 { get; set; }

        [MaxLength(250)]
        [Required]
        public string Mail { get; set; }

        [MaxLength(250)]
        [Required]
        public string WebSite { get; set; }

        [MaxLength(250)]
        [Required]
        public string MapLink { get; set; }
    }
}