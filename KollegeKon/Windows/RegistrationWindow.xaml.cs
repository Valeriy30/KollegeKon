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
            Button but = (Button)sender;
            switch(but.Name)
            {
                
                case  "StudBtn":
                    Hide();
                    StudentPage student = new StudentPage();
                    mainFrame.Navigate(student);
                    break;
                case "TeachBtn":
                    Hide();
                    TeacherPage teacher = new TeacherPage();
                    mainFrame.Navigate(teacher);
                    break;
                case "Taskbtn":
                    Hide();
                    TaskPage task = new TaskPage();
                    mainFrame.Navigate(task);
                    break;
                case "RoleBtn":
                    Hide();
                    RolePage role = new RolePage();
                    mainFrame.Navigate(role);
                    break;
                case "GradeBtn":
                    Hide();
                    GradePage grade = new GradePage();
                    mainFrame.Navigate(grade);
                    break;
                case "BuildBtn":
                    Hide();
                    BuildingPage build = new BuildingPage();
                    mainFrame.Navigate(build);
                    break;
                case "CabinetBtn":
                    Hide();
                    CabinetPage cabinet = new CabinetPage();
                    mainFrame.Navigate(cabinet);
                    break;
                case "AccountBtn":
                    Hide();
                    AccountPage account = new AccountPage();
                    mainFrame.Navigate(account);
                    break;
                case "CoupleBtn":
                    Hide();
                    CouplePage couple = new CouplePage();
                    mainFrame.Navigate(couple);
                    break;
                case "SheduleBtn":
                    Hide();
                    ShedulePage shedule = new ShedulePage();
                    mainFrame.Navigate(shedule);
                    break;
                case "JournalBtn":
                    Hide();
                    JournalPage journal = new JournalPage();
                    mainFrame.Navigate(journal);
                    break;
                case "GroupBtn":
                    Hide();
                    GroupPage group = new GroupPage();
                    mainFrame.Navigate(group);
                    break;


            }
            SpDg.Visibility = Visibility.Visible;
            BackBtn.Visibility = Visibility.Visible;
        }
        public void Hide()
        {
            RoleBtn.Visibility = Visibility.Hidden;
            StudBtn.Visibility = Visibility.Hidden;
            TeachBtn.Visibility = Visibility.Hidden;
            GradeBtn.Visibility = Visibility.Hidden;
            TaskBtn.Visibility = Visibility.Hidden;
            BuildBtn.Visibility = Visibility.Hidden;
            CabinetBtn.Visibility = Visibility.Hidden;
            AccountBtn.Visibility = Visibility.Hidden;
            CoupleBtn.Visibility = Visibility.Hidden;
            SheduleBtn.Visibility = Visibility.Hidden;
            JournalBtn.Visibility = Visibility.Hidden;
            GroupBtn.Visibility = Visibility.Hidden;

        }
        public void ReHide()
        {
            RoleBtn.Visibility = Visibility.Visible;
            StudBtn.Visibility = Visibility.Visible;
            TeachBtn.Visibility = Visibility.Visible;
            GradeBtn.Visibility = Visibility.Visible;
            TaskBtn.Visibility = Visibility.Visible;
            BuildBtn.Visibility = Visibility.Visible;
            CabinetBtn.Visibility = Visibility.Visible;
            AccountBtn.Visibility = Visibility.Visible;
            CoupleBtn.Visibility = Visibility.Visible;
            SheduleBtn.Visibility = Visibility.Visible;
            JournalBtn.Visibility = Visibility.Visible;
            GroupBtn.Visibility = Visibility.Visible;

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ReHide();
            SpDg.Visibility = Visibility.Hidden;
            BackBtn.Visibility = Visibility.Hidden;
        }
    }
}
