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
                    break;
                case "Преподаватели":
                    
                    TeacherPage teacher = new TeacherPage();
                    mainFrame.Navigate(teacher);
                    break;
                case "Задания":
                    
                    TaskPage task = new TaskPage();
                    mainFrame.Navigate(task);
                    break;
                case "Роли":
                    
                    RolePage role = new RolePage();
                    mainFrame.Navigate(role);
                    break;
                case "Оценки":
                    
                    GradePage grade = new GradePage();
                    mainFrame.Navigate(grade);
                    break;
                case "Здания":
                   
                    BuildingPage build = new BuildingPage();
                    mainFrame.Navigate(build);
                    break;
                case "Кабинеты":
                    
                    CabinetPage cabinet = new CabinetPage();
                    mainFrame.Navigate(cabinet);
                    break;
                case "Аккаунты":
                    ;AccountPage account = new AccountPage();
                    mainFrame.Navigate(account);
                    break;
                case "Пары":
                   
                    CouplePage couple = new CouplePage();
                    mainFrame.Navigate(couple);
                    break;
                case "Расписания":
                   
                    ShedulePage shedule = new ShedulePage();
                    mainFrame.Navigate(shedule);
                    break;
                case "Журнал":
                    
                    JournalPage journal = new JournalPage();
                    mainFrame.Navigate(journal);
                    break;
                case "Группы":
                  
                    GroupPage group = new GroupPage();
                    mainFrame.Navigate(group);
                    break;


            }
            SpDg.Visibility = Visibility.Visible;
            BackBtn.Visibility = Visibility.Visible;
        }
       

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
           
            SpDg.Visibility = Visibility.Hidden;
            
            Change = false;
        }
    }
}
