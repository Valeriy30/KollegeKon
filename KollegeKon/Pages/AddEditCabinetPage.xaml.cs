using KollegeKon.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
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
    /// Логика взаимодействия для AddEditCabinetPage.xaml
    /// </summary>
    public partial class AddEditCabinetPage : Page
    {
        private Cabinet cab = new Cabinet();
        public AddEditCabinetPage()
        {
            InitializeComponent();
            if (Change == true)
            {


                cab.Id = context.Cabinet.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Id;
                tbCabinet.Text = Convert.ToString( context.Cabinet.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Number);
                tbfloor.Text = Convert.ToString(context.Cabinet.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Floor);
                tbType.Text = context.Cabinet.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Type;

            }  
        }
        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCabinet.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbfloor.Text))
            {
                MessageBox.Show("Имя не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbType.Text))
            {
                MessageBox.Show("Фамилия не может быть пустым");
                return;
            }
           
           

            if (Change == false)
            {


                cab.Number = Convert.ToInt32(tbCabinet.Text);
               cab.Floor = Convert.ToInt32(tbfloor.Text);
                cab.Type = tbType.Text;
                context.Cabinet.Add(cab);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {
                cab.Number = Convert.ToInt32(tbCabinet.Text);
                cab.Floor = Convert.ToInt32(tbfloor.Text);
                cab.Type = tbType.Text;

                context.Cabinet.AddOrUpdate(cab);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;
        }
    }
}
