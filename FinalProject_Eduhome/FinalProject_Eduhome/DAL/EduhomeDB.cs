using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FinalProject_Eduhome.Models;

namespace FinalProject_Eduhome.DAL
{
    public class EduhomeDB:DbContext
    {
        public EduhomeDB() : base("EduhomeDBCon")
        {

        }

        public DbSet<About> About { get; set; }
        public DbSet<EduContacts> EduContacts { get; set; }
        public DbSet<EduAdmin> EduAdmin { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Slide> Slide { get; set; }
        public DbSet<EduSocials> EduSocials { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speakers> Speakers { get; set; }
        public DbSet<EventInfo> EventInfo { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<TeachContact> TeachContacts { get; set; }
        public DbSet<TeachSocial> TeachSocials { get; set; }
        public DbSet<TeachSkills> TeachSkills { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }
    }
}