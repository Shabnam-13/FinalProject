using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(500)]
        [Required]
        public string Content { get; set; }

        [MaxLength(500)]
        [Required]
        public string About { get; set; }

        [MaxLength(500)]
        [Required]
        public string Apply { get; set; }

        [MaxLength(500)]
        [Required]
        public string Certification { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFile { get; set; }

        [MaxLength(20)]
        [Required]
        public string StartDate { get; set; }

        [MaxLength(10)]
        [Required]
        public string Duration { get; set; }

        [MaxLength(10)]
        [Required]
        public string ClassDuration { get; set; }

        [MaxLength(25)]
        [Required]
        public string SkillLevel { get; set; }

        [MaxLength(20)]
        [Required]
        public string Language { get; set; }

        [Required]
        public int Students { get; set; }

        [MaxLength(20)]
        [Required]
        public string Assessments { get; set; }

        [MaxLength(10)]
        [Required]
        public string Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}