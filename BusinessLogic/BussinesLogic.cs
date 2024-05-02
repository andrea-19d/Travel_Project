﻿using BusinessLogic.DBModel;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBL() { 
            return new SessionBL ();

        }
        public IMonitoring GetMonitoringBL()
        {
            return new UserMonitoringBL();
        }

        public IProduct GetProductBL()
        {
            return new ProductBL ();
        }
    }
}
