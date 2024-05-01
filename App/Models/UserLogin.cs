using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
        public class userLogin
        {
            public string Username { get; set; }
            [Required(ErrorMessage = "Email is required")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }
            public DateTime RegisterDate { get; set; }
            public LevelAcces level { get; set; }
            public DateTime LoginDateTime { get; set; }
        }
}

