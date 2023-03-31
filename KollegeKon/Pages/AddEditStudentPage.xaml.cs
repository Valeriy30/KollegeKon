using KollegeKon.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        private Account account = new Account();
        public AddEditStudentPage()
        {
            InitializeComponent();
            cmbGen.ItemsSource = context.Gender.ToList();
            DataContext = stud;
            cmbGroup.DisplayMemberPath = "Name";
            cmbGroup.ItemsSource = context.Group.ToList();
            cmbGen.DisplayMemberPath = "Name";
            

            if (Change == true)
            {
                
                
                stud.Id= context.Student.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Id;
                tbFname.Text = context.Student.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Fname;
                tbLname.Text = context.Student.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Lname;
                tbPatronymic.Text = context.Student.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Patronymic;
                dpBirthDay.SelectedDate = context.Student.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Birthday;
                cmbGroup.SelectedIndex = context.Student.ToList().Where(i => i.Id == Idchange).FirstOrDefault().IdGroup;
                tbEmail.Text = context.Student.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Email;
                cmbGen.SelectedIndex = context.Student.ToList().Where(i => i.Id == Idchange).FirstOrDefault().IdGender;
                tbPhone.Text = context.Student.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Number; 
                tbAddress.Text = context.Student.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Address;
                tbLogin.Text = context.Account.ToList().Where(i => i.Id == context.Student.Where(o => o.Id == Idchange).FirstOrDefault().IdAccount ).FirstOrDefault().Login;
                tbPass.Text = context.Account.ToList().Where(i => i.Id == context.Student.Where(o => o.Id == Idchange).FirstOrDefault().IdAccount).FirstOrDefault().Password;
            }

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
            if (string.IsNullOrWhiteSpace(tbPass.Text))
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
                return;
            }
            if(cmbGroup.SelectedItem.Equals(null))
            {
                MessageBox.Show("Выберете группу");
                return;
            }
            if(string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Почта не может быть пустой");
                return;
            }
            if(string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустым");
                return;
            }
            if(string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Адрес не может быть пустым");
                return;
            }
            
            var authUser = context.Account.ToList()
              .Where(i => i.Login == tbLogin.Text && i.Password == tbPass.Text)
              .FirstOrDefault();
           
            if (Change == false)
            {
                if (authUser != null)
                {
                    MessageBox.Show("Логин занят");
                    return;
                }

                account.Login = tbLogin.Text;
                account.Password = tbPass.Text;
                account.IdRole = 3;

               
               stud.Fname = tbFname.Text;
                stud.Lname = tbLname.Text;
                stud.Patronymic = tbPatronymic.Text;
               stud.Number = tbPatronymic.Text;
               stud.Birthday = dpBirthDay.SelectedDate.Value;
               stud.IdGroup = (cmbGroup.SelectedItem as Group).Id;
               stud.Email = tbEmail.Text;
               stud.Number = tbPhone.Text;
               stud.IdGender = (cmbGen.SelectedItem as Gender).Id;
               stud.Address = tbAddress.Text;
                context.Account.Add(account);
                context.Student.Add(stud);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {
                account.Id = context.Account.ToList().Where(i => i.Id == context.Student.Where(o => o.Id == Idchange).FirstOrDefault().IdAccount).FirstOrDefault().Id;
                account.Login = tbLogin.Text;
                account.Password = tbPass.Text;
                account.IdRole = 3;
                   
              
               stud.Fname = tbFname.Text;
                stud.Lname = tbLname.Text;
                stud.Patronymic = tbPatronymic.Text;
               stud.Number = tbPatronymic.Text;
               stud.Birthday = dpBirthDay.SelectedDate.Value;
               stud.IdGroup = (cmbGroup.SelectedItem as Group).Id;
               stud.Email = tbEmail.Text;
               stud.Number = tbPhone.Text;
               stud.IdGender = (cmbGen.SelectedItem as Gender).Id;
               stud.Address = tbAddress.Text;
                stud.IdAccount = context.Student.Where(i => i.Id == Idchange).FirstOrDefault().IdAccount;
                context.Account.AddOrUpdate(account);
                context.Student.AddOrUpdate(stud);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;

        }
    }
    
}
