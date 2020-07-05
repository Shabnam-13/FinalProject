using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_Eduhome.Models
{
    public class Subscribe
    {
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}