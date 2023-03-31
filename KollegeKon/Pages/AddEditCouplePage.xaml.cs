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
    /// Логика взаимодействия для AddEditCouplePage.xaml
    /// </summary>
    public partial class AddEditCouplePage : Page
    {
        private Couple coup = new Couple();
        public AddEditCouplePage()
        {
            InitializeComponent();
            if (Change == true)
            {


                coup.Id = context.Role.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Id;
                tbCouple.Text = Convert.ToString(context.Couple.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Number);
                tbName.Text = Convert.ToString(context.Couple.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Name);
                dpDate.SelectedDate = context.Couple.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Date;
                tbTeacher.Text = Convert.ToString(context.Couple.ToList().Where(i => i.Id == Idchange).FirstOrDefault().IdTeacher);
                tbCabinet.Text = Convert.ToString(context.Couple.ToList().Where(i => i.Id == Idchange).FirstOrDefault().IdCabinet);

            }
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCabinet.Text))
            {
                MessageBox.Show("Номер кабинета не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Название не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbCabinet.Text))
            {
                MessageBox.Show("Номер кабинета не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbCouple.Text))
            {
                MessageBox.Show("Номер пары не может быть пустым");
                return;
            }




            if (Change == false)
            {

                coup.Date = dpDate.SelectedDate.Value;
                coup.Number = Convert.ToInt32(tbCouple.Text);
               coup.IdTeacher = Convert.ToInt32(tbTeacher.Text);
                coup.IdCabinet = Convert.ToInt32(tbCabinet.Text);
                coup.Name = tbName.Text;
                context.Couple.Add(coup);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {
                coup.Date = dpDate.SelectedDate.Value;
                coup.Number = Convert.ToInt32(tbCouple.Text);
                coup.IdTeacher = Convert.ToInt32(tbTeacher.Text);
                coup.IdCabinet = Convert.ToInt32(tbCabinet.Text);
                coup.Name = tbName.Text;

                context.Couple.AddOrUpdate(coup);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;
        }
    }
}
