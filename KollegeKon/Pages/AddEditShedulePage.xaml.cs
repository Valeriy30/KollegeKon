using KollegeKon.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для AddEditShedulePage.xaml
    /// </summary>
    public partial class AddEditShedulePage : Page
    {
        private Shedule shedule = new Shedule();
        public AddEditShedulePage()
        {
            InitializeComponent();
            if (Change == true)
            {


                shedule.IdCouple = context.Shedule.ToList().Where(i => i.IdCouple == Idchange).FirstOrDefault().IdCouple;
                tbCouple.Text = Convert.ToString(context.Shedule.ToList().Where(i => i.IdCouple == Idchange).FirstOrDefault().IdCouple);
                tbGroup.Text = Convert.ToString(context.Shedule.ToList().Where(i => i.IdCouple == Idchange).FirstOrDefault().IdGroup);
                dpDate.SelectedDate = context.Shedule.ToList().Where(i => i.IdCouple == Idchange).FirstOrDefault().Date;
            }
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCouple.Text))
            {
                MessageBox.Show("Номер роли не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbGroup.Text))
            {
                MessageBox.Show("Номер группы не может быть пустым");
                return;
            }
            if(string.IsNullOrWhiteSpace(dpDate.Text))
            {
                MessageBox.Show("Выберете дату");
                return;
            }

            if (Change == false)
            {


                shedule.IdCouple = Convert.ToInt32(tbCouple.Text);
                shedule.IdGroup = Convert.ToInt32(tbGroup.Text);
                shedule.Date = dpDate.SelectedDate.Value;
                context.Shedule.Add(shedule);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {

                shedule.IdCouple = Convert.ToInt32(tbCouple.Text);
                shedule.IdGroup = Convert.ToInt32(tbGroup.Text);
                shedule.Date = dpDate.SelectedDate.Value;
                context.Shedule.AddOrUpdate(shedule);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;
        }
    }
}
