using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.ViewModels
{
    public class SubscribeVM
    {
        public string Email { get; set; }

        public string Page { get; set; }

        public int CourseId { get; set; }

        public int ItemId { get; set; }
    }
}