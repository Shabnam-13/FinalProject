using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class Teachers
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(1000)]
        [Required]
        public string About { get; set; }

        [Display(Name = "Position")]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        [MaxLength(50)]
        [Required]
        public string Degree { get; set; }

        [MaxLength(25)]
        [Required]
        public string Experience { get; set; }

        [MaxLength(250)]
        [Required]
        public string Hobbies { get; set; }

        [Display(Name = "Faculty")]
        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFile { get; set; }

        public List<TeachContact> Contacts { get; set; }

        public List<TeachSocial> Socials { get; set; }

        public List<TeachSkills> Skills { get; set; }
    }
}