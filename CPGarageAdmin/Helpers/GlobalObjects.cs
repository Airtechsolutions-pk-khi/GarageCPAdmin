using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.DBEntities;

namespace CPGarage.Helpers
{
    public class GlobalObjects
    {
        public Garage_UATEntities DBContext = new Garage_UATEntities();
        

    }
}