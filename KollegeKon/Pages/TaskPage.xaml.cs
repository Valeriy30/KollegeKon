using KollegeKon.ClassHelper;
using KollegeKon.DB;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        public TaskPage()
        {
            InitializeComponent();
           
        
                dgTask.ItemsSource = context.Task.ToList();
            
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;

            EFClass.mainFrame.Navigate(new AddEditTaskPage());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditTaskPage edit = new AddEditTaskPage();

            EFClass.mainFrame.Navigate(edit);
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;
            var deleteTask = dgTask.SelectedItems.Cast<DB.Task>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    context.Task.RemoveRange(deleteTask);
                    context.SaveChanges();
                    MessageBox.Show("Удаленно");
                    dgTask.ItemsSource = context.Task.ToList();
                }
                catch (Exception ex)
                {


                }
            }
        }

        private void dgTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock tbCH = dgTask.Columns[0].GetCellContent(dgTask.Items[dgTask.SelectedIndex]) as TextBlock;
            Idchange = Convert.ToInt32(tbCH.Text);
        }
    }
}
