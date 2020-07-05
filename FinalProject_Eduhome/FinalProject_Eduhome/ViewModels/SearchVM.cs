using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.ViewModels
{
    public class SearchVM
    {
        public List<Event> Events { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Course> Courses { get; set; }

        public string Page { get; set; }
        public string SearchText { get; set; }
    }
}