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
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
            dgAccount.ItemsSource = context.Account.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;

            EFClass.mainFrame.Navigate(new AddEditAccountPage());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

            Change = true;
            AddEditAccountPage edit = new AddEditAccountPage();

            EFClass.mainFrame.Navigate(edit);
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;
            var deleteAccount = dgAccount.SelectedItems.Cast<Account>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    context.Account.RemoveRange(deleteAccount);
                    context.SaveChanges();
                    MessageBox.Show("Удаленно");
                    dgAccount.ItemsSource = context.Account.ToList();
                }
                catch (Exception ex)
                {


                }
            }
        }

        private void dgAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock tbCH = dgAccount.Columns[0].GetCellContent(dgAccount.Items[dgAccount.SelectedIndex]) as TextBlock;
            Idchange = Convert.ToInt32(tbCH.Text);
        }
    }
}
