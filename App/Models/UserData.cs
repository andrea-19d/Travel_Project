﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    internal interface UserData
    {
        public string UserName { get; set; }
        public List<string> Products { get; set; }
    }
}
