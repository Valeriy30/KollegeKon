using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KollegeKon.ClassHelper;
using KollegeKon.DB;
using KollegeKon.Pages;
using static System.Net.Mime.MediaTypeNames;
using static KollegeKon.ClassHelper.EFClass;

namespace KollegeKon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Date = DateTime.Now;
            lbDate.Content = DateTime.Now.ToString().Substring(0, 10);
            lbTime.Content = DateTime.Now.ToShortTimeString();
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { lbDate.Content = DateTime.Now.ToString().Substring(0,10); };
            timer.Tick += (o, t) => { lbTime.Content = DateTime.Now.ToShortTimeString(); };
            timer.Start();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Log log = new Log();
            log.Date = Date;
            log.LogInTime = Login.ToString().Substring(0,8);
            log.LogOutTime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
            log.TimeSpent = (DateTime.Now.TimeOfDay - Login).ToString().Substring(1, 7);
            log.IdAccount = IdAuthorization;
            context.Log.Add(log);
            context.SaveChanges();
            

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = (MenuItem)sender;
            switch (menu.Header)
            {
                case "Расписание":

                    ShedulePage shedule = new ShedulePage();
                    mainFrame.Navigate(shedule);
                    break;
                case "Оценки":

                    GradePage Grade = new GradePage();
                    mainFrame.Navigate(Grade);
                    break;
            }
        }

       
    }
    
}
