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
            
            var query =
           from Student in context.Student
           select new { Student.Fname, Student.Lname,Student.Patronymic, Student.Birthday, Student.IdGroup,Student.Email,Student.Number,Student.IdGender,Student.City, Student.Street, Student.House,Student.Aparatment, Student.IdAccount };

            
           
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

            }
            SpDg.Visibility = Visibility.Visible;
        }
        public void Hide()
        {
            RoleBtn.Visibility = Visibility.Hidden;
            StudBtn.Visibility = Visibility.Hidden;
            Teachbtn.Visibility = Visibility.Hidden;
            GradeBtn.Visibility = Visibility.Hidden;
            TaskBtn.Visibility = Visibility.Hidden;
            BuildBtn.Visibility = Visibility.Hidden;
            CabinetBtn.Visibility = Visibility.Hidden;
            AccountBtn.Visibility = Visibility.Hidden;
            CoupleBtn.Visibility = Visibility.Hidden;

        }
        public void ReHide()
        {
            RoleBtn.Visibility = Visibility.Visible;
            StudBtn.Visibility = Visibility.Visible;
            Teachbtn.Visibility = Visibility.Visible;
            GradeBtn.Visibility = Visibility.Visible;
            TaskBtn.Visibility = Visibility.Visible;
            BuildBtn.Visibility = Visibility.Visible;
            CabinetBtn.Visibility = Visibility.Visible;
            AccountBtn.Visibility = Visibility.Visible;
            CoupleBtn.Visibility = Visibility.Visible;

        }
    }
}
