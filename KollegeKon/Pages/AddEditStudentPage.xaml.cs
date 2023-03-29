using KollegeKon.DB;
using System;
using System.Collections.Generic;
using System.Linq;
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
using static KollegeKon.ClassHelper.EFClass;

namespace KollegeKon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditStudentPage.xaml
    /// </summary>
    public partial class AddEditStudentPage : Page
    {
        private Student stud = new Student();
        public AddEditStudentPage()
        {
            InitializeComponent();
            cmbGen.ItemsSource = context.Gender.ToList();
            DataContext = stud;
            cmbGroup.DisplayMemberPath = "Name";
            cmbGroup.ItemsSource = context.Group.ToList();
            cmbGen.DisplayMemberPath = "Name";

        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(tbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbFname.Text))
            {
                MessageBox.Show("Имя не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbLname.Text))
            {
                MessageBox.Show("Фамилия не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(pbPass.Password))
            {
                MessageBox.Show("Пароль не может быть пустым");

                return;
            }
            if (string.IsNullOrWhiteSpace(dpBirthDay.Text))
            {

                MessageBox.Show("Дата не может быть пустой");
                return;
            }
            if (cmbGen.SelectedItem.Equals(null)) 
            {
                MessageBox.Show("Выберете пол");
            }
            if(cmbGroup.SelectedItem.Equals(null))
            {
                MessageBox.Show("Выберете группу");
            }
            if(string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Почта не может быть пустой");
            }
            if(string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустым");
            }
            if(string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Адрес не может быть пустым");
            }
            var authUser = context.Account.ToList()
              .Where(i => i.Login == tbLogin.Text && i.Password == pbPass.Password)
              .FirstOrDefault();
            if (authUser != null)
            {
                MessageBox.Show("Логин занят");
                return;
            }
            DB.Account acc = new DB.Account();
            acc.Login = tbLogin.Text;
            acc.Password = pbPass.Password;
            acc.IdRole = 3;
            DB.Student student = new DB.Student();
            student.Lname = tbFname.Text;
            student.Fname = tbLname.Text;
            student.Patronymic = tbPhone.Text;
            student.Number = tbPatronymic.Text;
            student.Birthday = dpBirthDay.SelectedDate.Value;
            student.IdGroup = (cmbGroup.SelectedItem as Group).Id;
            student.Email = tbEmail.Text;
            student.Number = tbPhone.Text;
            student.IdGender = (cmbGen.SelectedItem as Gender).Id;
            student.Address = tbAddress.Text;
            context.Account.Add(acc);
            context.Student.Add(student);
            context.SaveChanges();
            MessageBox.Show("Ok");
        }
    }
    
}
