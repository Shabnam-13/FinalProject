using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.ViewModels
{
    public class MessageVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Page { get; set; }
        public int ItemId { get; set; }
    }
}