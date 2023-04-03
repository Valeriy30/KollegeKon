using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public static int Idchange = 0;
        public static bool Change = false ;
        public static DateTime Date;
        public static TimeSpan Login ;
       
        public static int IdAuthorization;
    }
}
