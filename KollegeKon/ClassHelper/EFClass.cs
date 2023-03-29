using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KollegeKon.DB;

namespace KollegeKon.ClassHelper
{
    public  class EFClass
    {
        public static KollegeEntities context { get; set; } = new KollegeEntities();
        public static Frame mainFrame { get; set; }
    
    }
}
