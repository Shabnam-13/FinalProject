using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class Event
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Title { get; set; }

        [MaxLength(3000)]
        [Required]
        public string Content { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [MaxLength(20)]
        [Required]
        public string EventTime { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [MaxLength(100)]
        [Required]
        public string Venue { get; set; }

        [MaxLength(50)]
        [Required]
        public string City { get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<EventInfo> Infos { get; set; }
    }
}