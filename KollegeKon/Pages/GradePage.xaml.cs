using KollegeKon.ClassHelper;
using KollegeKon.DB;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для GradePage.xaml
    /// </summary>
    public partial class GradePage : Page
    {
        public GradePage()
        {
            InitializeComponent();
            if (RoleAdmin == false)
            {
                dgGrade.ItemsSource = context.Grade.Where(i => i.IdStudent== context.Student.Where(o => o.IdAccount==IdAuthorization).FirstOrDefault().Id).ToList();
                wpAdmin.Visibility = Visibility.Hidden;
            }
            else
            {
                dgGrade.ItemsSource = context.Grade.ToList();
            }
        }


        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;
            EFClass.mainFrame.Navigate(new AddEditGradePage());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditGradePage edit = new AddEditGradePage();

            EFClass.mainFrame.Navigate(edit);
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;
            var deleteGrade = dgGrade.SelectedItems.Cast<Grade>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    context.Grade.RemoveRange(deleteGrade);
                    context.SaveChanges();
                    MessageBox.Show("Удаленно");
                    dgGrade.ItemsSource = context.Grade.ToList();
                }
                catch (Exception ex)
                {


                }
            }
        }

       
    }
    
}
