using KollegeKon.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
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
    /// Логика взаимодействия для AddEditTaskPage.xaml
    /// </summary>
    public partial class AddEditTaskPage : Page
    {
        private DB.Task task = new DB.Task();
        public AddEditTaskPage()
        {
            InitializeComponent();
            if (Change == true)
            {


                task.Id = context.Task.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Id;
                tbdesc.Text = context.Task.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Description;
                tbTeach.Text = Convert.ToString(context.Task.ToList().Where(i => i.Id == Idchange).FirstOrDefault().IdTeacher);
                

            }
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbdesc.Text))
            {
                MessageBox.Show("Название роли не может быть пустым");
                return;
            }

            if (Change == false)
            {


                task.Description = tbdesc.Text;
                task.IdTeacher = Convert.ToInt32(tbTeach.Text);
               
                context.Task.Add(task);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {

                task.Description = tbdesc.Text;
                task.IdTeacher = Convert.ToInt32(tbTeach.Text);
                context.Task.AddOrUpdate(task);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;
        }
    }
}
