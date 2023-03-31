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
    /// Логика взаимодействия для AddEditBuildingPage.xaml
    /// </summary>
    public partial class AddEditBuildingPage : Page
    {
        private Building build = new Building();
        public AddEditBuildingPage()
        {
            InitializeComponent();
            if (Change == true)
            {

                build.Id = context.Building.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Id;
                tbAddress.Text = context.Building.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Address;
               
            }
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Адрес не может быть пустым");
                return;
            }

            if (Change == false)
            {


                build.Address = tbAddress.Text;
               

                context.Building.Add(build);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {

                build.Address = tbAddress.Text;
                context.Building.AddOrUpdate(build);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;
        }
    }
}
