using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        public List<Event> Events { get; set; }

        public List<Blog> Blogs { get; set; }

        public List<Course> Courses { get; set; }
    }
}