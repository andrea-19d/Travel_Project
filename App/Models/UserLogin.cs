using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
        public class userLogin
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
  /*          public string LoginIp { get; set; }*/
            public LevelAcces level { get; set; }
            public DateTime LoginDateTime { get; set; }
        }
}

