using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Web.Models
{
    public class UserData
    {
        public string UserName { get; set; }
        public List<string> Products { get; set; }
    }
}