using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class Slide
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Title { get; set; }

        [MaxLength(250)]
        [Required]
        public string Subtitle { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [Display(Name = "Image")]
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}