using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class  ULoginData
    {
        public string Credential { get; set;}
        public string Password { get; set;}
        public string LoginIp { get; set;}
        public DateTime LoginDataTime {get ; set;}
    }
}
