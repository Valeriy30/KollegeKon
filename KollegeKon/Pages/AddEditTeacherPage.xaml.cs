using KollegeKon.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
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
using static KollegeKon.ClassHelper.EFClass;

namespace KollegeKon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditTeacherPage.xaml
    /// </summary>
    public partial class AddEditTeacherPage : Page
    {
        private Teacher teach = new Teacher();
        private Account account = new Account();
        public AddEditTeacherPage()
        {
            InitializeComponent();
            cmbGen.ItemsSource = context.Gender.ToList();
            DataContext = teach;
           
            cmbGen.DisplayMemberPath = "Name";
            if (Change == true)
            {


                teach.Id = context.Teacher.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Id;
                tbFname.Text = context.Teacher.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Fname;
                tbLname.Text = context.Teacher.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Lname;
                tbPatronymic.Text = context.Teacher.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Patronymic;
                dpBirthDay.SelectedDate = context.Teacher.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Birthday;
                tbSpeciality.Text = context.Teacher.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Speciality;
                tbEmail.Text = context.Teacher.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Email;
                cmbGen.SelectedIndex = context.Teacher.ToList().Where(i => i.Id == Idchange).FirstOrDefault().IdGender;
                tbPhone.Text = context.Teacher.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Number;
                tbAddress.Text = context.Teacher.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Address;
                tbLogin.Text = context.Account.ToList().Where(i => i.Id == context.Teacher.Where(o => o.Id == Idchange).FirstOrDefault().IdAccount).FirstOrDefault().Login;
                tbPass.Text = context.Account.ToList().Where(i => i.Id == context.Teacher.Where(o => o.Id == Idchange).FirstOrDefault().IdAccount).FirstOrDefault().Password;
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
            if (string.IsNullOrWhiteSpace(tbSpeciality.Text))
            {
                MessageBox.Show("Введите специалность");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                MessageBox.Show("Почта не может быть пустой");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
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

                teach.Lname = tbFname.Text;
                teach.Fname = tbLname.Text;
                teach.Patronymic = tbPatronymic.Text;
                teach.Number = tbPatronymic.Text;
                teach.Birthday = dpBirthDay.SelectedDate.Value;
                teach.Speciality = tbSpeciality.Text;
                teach.Email = tbEmail.Text;
                teach.Number = tbPhone.Text;
                teach.IdGender = (cmbGen.SelectedItem as Gender).Id;
                teach.Address = tbAddress.Text;
                context.Account.Add(account);
                context.Teacher.Add(teach);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {
                account.Id = context.Account.ToList().Where(i => i.Id == context.Student.Where(o => o.Id == Idchange).FirstOrDefault().IdAccount).FirstOrDefault().Id;
                account.Login = tbLogin.Text;
                account.Password = tbPass.Text;
                account.IdRole = 3;

                teach.Lname = tbFname.Text;
                teach.Fname = tbLname.Text;
                teach.Patronymic = tbPatronymic.Text;
                teach.Number = tbPatronymic.Text;
                teach.Birthday = dpBirthDay.SelectedDate.Value;
                teach.Speciality = tbSpeciality.Text;
                teach.Email = tbEmail.Text;
                teach.Number = tbPhone.Text;
                teach.IdGender = (cmbGen.SelectedItem as Gender).Id;
                teach.Address = tbAddress.Text;
                teach.IdAccount = context.Student.Where(i => i.Id == Idchange).FirstOrDefault().IdAccount;
                context.Account.AddOrUpdate(account);
                context.Teacher.AddOrUpdate(teach);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;

        }
    }
}
