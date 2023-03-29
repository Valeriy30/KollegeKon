using KollegeKon.ClassHelper;
using KollegeKon.DB;
using KollegeKon.Windows;
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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>

    public partial class StudentPage : Page
    {

        public StudentPage()
        {
            InitializeComponent();
            dgStudent.ItemsSource = context.Student.ToList();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {



            EFClass.mainFrame.Navigate(new AddEditStudentPage());

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var deleteStud = dgStudent.SelectedItems.Cast<Student>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    context.Student.RemoveRange(deleteStud);
                    context.SaveChanges();
                    MessageBox.Show("Удаленно");
                    dgStudent.ItemsSource = context.Student.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
 }
