using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class Speakers
    {
        public int Id { get; set; }

        [MaxLength(500)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Position { get; set; }

        [MaxLength(50)]
        [Required]
        public string Company { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFile { get; set; }

        public List<EventInfo> Events { get; set; }
    }
}