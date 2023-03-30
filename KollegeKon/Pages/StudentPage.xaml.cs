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
            AddEditStudentPage edit = new AddEditStudentPage();
           
            


        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            Idchange = 0;

            EFClass.mainFrame.Navigate(new AddEditStudentPage());

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;
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
                    
                    
                }
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditStudentPage edit = new AddEditStudentPage();
           
            EFClass.mainFrame.Navigate(edit);
           

        }

        private void dgStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock tbCH = dgStudent.Columns[0].GetCellContent(dgStudent.Items[dgStudent.SelectedIndex]) as TextBlock;
            Idchange = Convert.ToInt32(tbCH.Text);
            
        }
    }
 }
