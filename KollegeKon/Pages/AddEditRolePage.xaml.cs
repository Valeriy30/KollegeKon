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
    /// Логика взаимодействия для AddEditRolePage.xaml
    /// </summary>
    public partial class AddEditRolePage : Page
    {
        private Role rol = new Role();
        public AddEditRolePage()
        {
            InitializeComponent();
            if (Change == true)
            {


                rol.Id = context.Role.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Id;
                tbRole.Text = Convert.ToString(context.Role.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Name);
                

            }
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbRole.Text))
            {
                MessageBox.Show("Название роли не может быть пустым");
                return;
            }

            if (Change == false)
            {


                rol.Name = tbRole.Text;

                context.Role.Add(rol);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {

                rol.Name = tbRole.Text;
                context.Role.AddOrUpdate(rol);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;
        }
    }
}
