using KollegeKon.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для AddEditAccountPage.xaml
    /// </summary>
    public partial class AddEditAccountPage : Page
    {
        private Account account = new Account();
        public AddEditAccountPage()
        {
            InitializeComponent();
            cmbRole.ItemsSource = context.Role.ToList();
            DataContext = account;
            cmbRole.DisplayMemberPath = "Name";
            if (Change == true)
            {


                account.Id = context.Account.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Id;
                tbLogin.Text = Convert.ToString(context.Account.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Login);
                tbPassword.Text = Convert.ToString(context.Account.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Password);
                cmbRole.SelectedIndex = context.Account.ToList().Where(i => i.Id == Idchange).FirstOrDefault().IdRole;

            }
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text))
            {
                MessageBox.Show("Название роли не может быть пустым");
                return;
            }

            if (Change == false)
            {


                account.Login = tbLogin.Text;
                account.Password = tbPassword.Text;
                account.IdRole = (cmbRole.SelectedItem as Role).Id;
                context.Account.Add(account);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {

                account.Login = tbLogin.Text;
                account.Password = tbPassword.Text;
                account.IdRole = (cmbRole.SelectedItem as Role).Id;
                context.Account.AddOrUpdate(account);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;
        }
    }
}
