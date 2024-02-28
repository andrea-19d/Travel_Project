using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    internal class BussinesLogic
    {
        public ISession GetSessionBL() { 
            return new SessionBL ();

        }
        public IProduct GetProductBL()
        {
            return new ProductBL  ();
        }
    }
}
