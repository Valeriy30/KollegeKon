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
    /// Логика взаимодействия для CouplePage.xaml
    /// </summary>
    public partial class CouplePage : Page
    {
        public CouplePage()
        {
            InitializeComponent();
            dgCouple.ItemsSource = context.Couple.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;

            EFClass.mainFrame.Navigate(new AddEditCouplePage());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditCouplePage edit = new AddEditCouplePage();

            EFClass.mainFrame.Navigate(edit);
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;
            var deleteCoup = dgCouple.SelectedItems.Cast<Couple>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    context.Couple.RemoveRange(deleteCoup);
                    context.SaveChanges();
                    MessageBox.Show("Удаленно");
                    dgCouple.ItemsSource = context.Couple.ToList();
                }
                catch (Exception ex)
                {


                }
            }
        }

        private void dgCouple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock tbCH = dgCouple.Columns[0].GetCellContent(dgCouple.Items[dgCouple.SelectedIndex]) as TextBlock;
            Idchange = Convert.ToInt32(tbCH.Text);
        }
    }
}
