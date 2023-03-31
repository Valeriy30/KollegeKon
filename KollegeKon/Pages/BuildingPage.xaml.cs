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
    /// Логика взаимодействия для BuildingPage.xaml
    /// </summary>
    public partial class BuildingPage : Page
    {
        public BuildingPage()
        {
            InitializeComponent();
            dgBuilding.ItemsSource = context.Building.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;
            EFClass.mainFrame.Navigate(new AddEditBuildingPage());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditBuildingPage edit = new AddEditBuildingPage();

            EFClass.mainFrame.Navigate(edit);
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;
            var deleteBuilding = dgBuilding.SelectedItems.Cast<Building>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    context.Building.RemoveRange(deleteBuilding);
                    context.SaveChanges();
                    MessageBox.Show("Удаленно");
                    dgBuilding.ItemsSource = context.Building.ToList();
                }
                catch (Exception ex)
                {


                }
            }
        }

        private void dgBuilding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock tbCH = dgBuilding.Columns[0].GetCellContent(dgBuilding.Items[dgBuilding.SelectedIndex]) as TextBlock;
            Idchange = Convert.ToInt32(tbCH.Text);
        }
    }
}
