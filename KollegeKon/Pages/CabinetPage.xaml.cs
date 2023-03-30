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
    /// Логика взаимодействия для CabinetPage.xaml
    /// </summary>
    public partial class CabinetPage : Page
    {
        public CabinetPage()
        {
            InitializeComponent();
            dgCabinet.ItemsSource = context.Cabinet.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;

            EFClass.mainFrame.Navigate(new AddEditCabinetPage());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditCabinetPage edit = new AddEditCabinetPage();

            EFClass.mainFrame.Navigate(edit);
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {

            Idchange = 0;
            var deleteCab = dgCabinet.SelectedItems.Cast<Cabinet>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    context.Cabinet.RemoveRange(deleteCab);
                    context.SaveChanges();
                    MessageBox.Show("Удаленно");
                    dgCabinet.ItemsSource = context.Cabinet.ToList();
                }
                catch (Exception ex)
                {


                }
            }
        }

        private void dgCabinet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            TextBlock tbCH = dgCabinet.Columns[0].GetCellContent(dgCabinet.Items[dgCabinet.SelectedIndex]) as TextBlock;
            Idchange = Convert.ToInt32(tbCH.Text);
        }
    }
}
