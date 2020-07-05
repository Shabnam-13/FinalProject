using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class EduAdmin
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [MaxLength(20)]
        [Required]
        public string Surname { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }

        [MaxLength(250)]
        [MinLength(8)]
        [Required]
        public string Password { get; set; }

        [MaxLength(250)]
        [Required]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [Display(Name = "Image")]
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}