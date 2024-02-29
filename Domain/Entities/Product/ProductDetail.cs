using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{    
        public class ProductDetail
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public int Duration { get; set; }
            public int Start { get; set; }
            public List<Outline> OutlineObj { get; set; }
        }
        public class Outline
        {
            public string Topic { get; set; }
            public string Time { get; set; }
            public bool Status { get; set; }
        }
    
}
