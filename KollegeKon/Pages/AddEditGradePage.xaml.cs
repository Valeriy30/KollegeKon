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
    /// Логика взаимодействия для AddEditGradePage.xaml
    /// </summary>
    public partial class AddEditGradePage : Page
    {
        private Grade grade = new Grade();
        public AddEditGradePage()
        {
            InitializeComponent();
            if (Change == true)
            {


                grade.Id = context.Grade.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Id;
                tbGrade.Text = Convert.ToString(context.Grade.ToList().Where(i => i.Id == Idchange).FirstOrDefault().Grade1);
                tbCouple.Text = Convert.ToString(context.Grade.ToList().Where(i => i.Id == Idchange).FirstOrDefault().IdCouple);
                tbStudent.Text = Convert.ToString(context.Grade.ToList().Where(i => i.Id == Idchange).FirstOrDefault().IdStudent);
                tbTeacher.Text = Convert.ToString(context.Grade.ToList().Where(i => i.Id == Idchange).FirstOrDefault().IdTeacher);


            }
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbGrade.Text))
            {
                MessageBox.Show("Название роли не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbGrade.Text))
            {
                MessageBox.Show("Название роли не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbGrade.Text))
            {
                MessageBox.Show("Название роли не может быть пустым");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbGrade.Text))
            {
                MessageBox.Show("Название роли не может быть пустым");
                return;
            }

            if (Change == false)
            {


                grade.Grade1 = Convert.ToInt32( tbGrade.Text);
                grade.IdTeacher = Convert.ToInt32(tbTeacher.Text);
                grade.IdCouple = Convert.ToInt32(tbCouple.Text);
                grade.IdStudent = Convert.ToInt32(tbStudent.Text);

                context.Grade.Add(grade);
                context.SaveChanges();
                MessageBox.Show("O");
            }
            else
            {

                grade.Grade1 = Convert.ToInt32(tbGrade.Text);
                grade.IdTeacher = Convert.ToInt32(tbTeacher.Text);
                grade.IdCouple = Convert.ToInt32(tbCouple.Text);
                grade.IdStudent = Convert.ToInt32(tbStudent.Text);
                context.Grade.AddOrUpdate(grade);
                context.SaveChanges();
                MessageBox.Show("Ok");
            }
            Change = false;
        }
    }
}
