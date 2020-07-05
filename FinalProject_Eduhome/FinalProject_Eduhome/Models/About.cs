using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class About
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Content { get; set; }

        [MaxLength(250)]
        public string VideoLink { get; set; }

        [MaxLength(50)]
        [Required]
        public string Copyright { get; set; }

        [MaxLength(250)]
        public string Logo { get; set; }

        [NotMapped]
        [Display(Name = "Logo")]
        public HttpPostedFileBase LogoFile { get; set; }

        [MaxLength(250)]
        public string Icon { get; set; }

        [NotMapped]
        [Display(Name = "Icon")]
        public HttpPostedFileBase IconFile { get; set; }

        [MaxLength(250)]
        public string IconWhite { get; set; }

        [NotMapped]
        [Display(Name = "White Icon")]
        public HttpPostedFileBase IconWhiteFile { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFile { get; set; }

        [MaxLength(250)]
        public string BgImage { get; set; }

        [NotMapped]
        [Display(Name = "Background Image")]
        public HttpPostedFileBase BgImageFile { get; set; }

        [MaxLength(250)]
        public string VideoImage { get; set; }

        [NotMapped]
        [Display(Name = "Video Image")]
        public HttpPostedFileBase VideoImageFile { get; set; }

        [MaxLength(250)]
        public string PrllxImage { get; set; }

        [NotMapped]
        [Display(Name = "Parallax Image")]
        public HttpPostedFileBase PrllxImageFile { get; set; }

        [MaxLength(250)]
        public string SidebarImage { get; set; }

        [NotMapped]
        [Display(Name = "Sidebar Image")]
        public HttpPostedFileBase SidebarImageFile { get; set; }
    }
}