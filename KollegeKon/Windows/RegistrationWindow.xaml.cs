using KollegeKon.ClassHelper;
using KollegeKon.DB;
using KollegeKon.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
using System.Windows.Shapes;
using static KollegeKon.ClassHelper.EFClass;
namespace KollegeKon.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            Date = DateTime.Now;
            lbDate.Content = DateTime.Now.ToString().Substring(0, 10);
            lbTime.Content = DateTime.Now.ToShortTimeString();
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { lbDate.Content = DateTime.Now.ToString().Substring(0, 10); };
            timer.Tick += (o, t) => { lbTime.Content = DateTime.Now.ToShortTimeString(); };
            timer.Start();
            EFClass.mainFrame = mainFrame;
            
           
        }

        private void btn_ItemSourceCick(object sender, RoutedEventArgs e)
        {
            MenuItem menu = (MenuItem)sender;
            switch(menu.Header)
            {
                
                case  "Студенты":
                    
                    StudentPage student = new StudentPage();
                    mainFrame.Navigate(student);
                    TbTitle.Text = "Студенты";
                    break;
                case "Преподаватели":
                    
                    TeacherPage teacher = new TeacherPage();
                    mainFrame.Navigate(teacher);
                    TbTitle.Text = "Преподаватели";
                    break;
                case "Задания":
                    
                    TaskPage task = new TaskPage();
                    mainFrame.Navigate(task);
                    TbTitle.Text = "Задания";
                    break;
                case "Роли":
                    
                    RolePage role = new RolePage();
                    mainFrame.Navigate(role);
                    TbTitle.Text = "Роли";
                    break;
                case "Оценки":
                    
                    GradePage grade = new GradePage();
                    mainFrame.Navigate(grade);
                    TbTitle.Text = "Оценки";
                    break;
                case "Здания":
                   
                    BuildingPage build = new BuildingPage();
                    mainFrame.Navigate(build);
                    TbTitle.Text = "Здания";
                    break;
                case "Кабинеты":
                    
                    CabinetPage cabinet = new CabinetPage();
                    TbTitle.Text = "Кабинеты";
                    mainFrame.Navigate(cabinet);
                    break;
                case "Аккаунты":
                    ;AccountPage account = new AccountPage();
                    TbTitle.Text = "Аккаунты";
                    mainFrame.Navigate(account);
                    break;
                case "Пары":
                   
                    CouplePage couple = new CouplePage();
                    TbTitle.Text = "Пары";
                    mainFrame.Navigate(couple);
                    break;
                case "Расписания":
                   
                    ShedulePage shedule = new ShedulePage();
                    TbTitle.Text = "Расписания";
                    mainFrame.Navigate(shedule);
                    break;
                case "Журнал":
                    
                    JournalPage journal = new JournalPage();
                    mainFrame.Navigate(journal);
                    TbTitle.Text = "Журнал";
                    break;
                case "Группы":
                  
                    GroupPage group = new GroupPage();
                    mainFrame.Navigate(group);
                    TbTitle.Text = "Группы";
                    break;


            }
            SpDg.Visibility = Visibility.Visible;
            
        }
       

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
           
            SpDg.Visibility = Visibility.Hidden;
            
            Change = false;
        }
        private void statisctics_Click (object sender, RoutedEventArgs e)
        {
            StatisticsWindow statka = new StatisticsWindow();
            statka.Show();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Log log = new Log();
            log.Date = Date;
            log.LogInTime = Login.ToString().Substring(0, 8);
            log.LogOutTime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
            log.TimeSpent = (DateTime.Now.TimeOfDay - Login).ToString().Substring(1, 7);
            log.IdAccount = IdAuthorization;
            context.Log.Add(log);
            context.SaveChanges();
        }
    }
}
