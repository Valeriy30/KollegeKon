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
using System.Xml.Linq;
using static KollegeKon.ClassHelper.EFClass;

namespace KollegeKon.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditGroupPage.xaml
    /// </summary>
    public partial class AddEditGroupPage : Page
    {
        private Group group = new Group();
        public AddEditGroupPage()
        {
            
            InitializeComponent();
            if (Change == true)
            {


                group.Id = context.Group.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Id;
                tbGroup.Text = context.Group.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Name;
                tbSpeciality.Text = Convert.ToString(context.Group.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Speciality);
                
            }
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbGroup.Text))
            {
                MessageBox.Show("Номер кабинета не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbSpeciality.Text))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }
            

            if (Change == false)
            {


                group.Speciality = tbSpeciality.Text;
                group.Name = tbGroup.Text;
                context.Group.Add(group);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {
                
                group.Name = tbGroup.Text;
                group.Speciality = tbSpeciality.Text;
                context.Group.AddOrUpdate(group);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;
        }
    }
}
