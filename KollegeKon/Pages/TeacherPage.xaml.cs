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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
            dgTeacher.ItemsSource = context.Teacher.ToList();
        }

        private void dgTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock tbCH = dgTeacher.Columns[0].GetCellContent(dgTeacher.Items[dgTeacher.SelectedIndex]) as TextBlock;
            Idchange = Convert.ToInt32(tbCH.Text);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;

            EFClass.mainFrame.Navigate(new AddEditTeacherPage());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Change = true;
            AddEditTeacherPage edit = new AddEditTeacherPage();

            EFClass.mainFrame.Navigate(edit);
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            Idchange = 0;
            var deleteTeach= dgTeacher.SelectedItems.Cast<Teacher>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    context.Teacher.RemoveRange(deleteTeach);
                    context.SaveChanges();
                    MessageBox.Show("Удаленно");
                    dgTeacher.ItemsSource = context.Teacher.ToList();
                }
                catch (Exception ex)
                {


                }
            }
        }

        private void Fname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
