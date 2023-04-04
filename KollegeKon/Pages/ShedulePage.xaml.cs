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
    /// Логика взаимодействия для ShedulePage.xaml
    /// </summary>
    public partial class ShedulePage : Page
    {
        public ShedulePage()
        {
            InitializeComponent();
            if (RoleAdmin == false)
            {
                dgShedule.ItemsSource = context.Shedule.Where(i => i.IdGroup == context.Group.Where(o => o.Id == context.Student.Where(p => p.Id == IdAuthorization).FirstOrDefault().IdGroup).FirstOrDefault().Id).ToList() ;
                wpAdmin.Visibility = Visibility.Hidden;
            }
            else 
            {
                dgShedule.ItemsSource = context.Shedule.ToList();
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;

            EFClass.mainFrame.Navigate(new AddEditShedulePage());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditShedulePage edit = new AddEditShedulePage();

            EFClass.mainFrame.Navigate(edit);
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;
            var deleteShedule = dgShedule.SelectedItems.Cast<Shedule>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    context.Shedule.RemoveRange(deleteShedule);
                    context.SaveChanges();
                    MessageBox.Show("Удаленно");
                    dgShedule.ItemsSource = context.Shedule.ToList();
                }
                catch (Exception ex)
                {


                }
            }
        }

        
    }
}
