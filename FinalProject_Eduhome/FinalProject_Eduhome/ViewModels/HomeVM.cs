using FinalProject_Eduhome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.ViewModels
{
    public class HomeVM
    {
        public List<Slide> Slides { get; set; }
        public List<Course> Courses { get; set; }
        public List<Event> Events { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<EduSocials> EduSocials { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<Teachers> Teachers { get; set; }
        public List<TeachSocial> TeachSocials { get; set; }
        public List<TeachSkills> TeachSkills { get; set; }
        public List<EventInfo> EventInfos { get; set; }
        public List<Speakers> Speakers { get; set; }


        public List<Category> Categories { get; set; }
        public List<Position> Positions { get; set; }
        public List<Faculty> Faculties { get; set; }


        public Course course { get; set; }
        public Event event1 { get; set; }
        public Blog blog { get; set; }
        public Teachers teacher { get; set; }

        public TeachContact teachContact { get; set; }
        public About about { get; set; }
        public EduContacts eduContacts { get; set; }

        public int pageCount { get; set; }
        public int currentPage { get; set; }
    }
}