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
            dgTeacher.ItemsSource = context.Teacher.ToList().Where(i => i.Fname.Contains(Fname.Text));
        }

        private void Lname_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgTeacher.ItemsSource = context.Teacher.ToList().Where(i => i.Lname.Contains(Lname.Text));
        }

        private void Speciality_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgTeacher.ItemsSource = context.Teacher.ToList().Where(i => i.Speciality.Contains(Speciality.Text));
        }

        private void chb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            switch (cb.Name)
            {
                case "chbGen":
                    if (chbGen.IsChecked == false) colIdGender.Visibility = Visibility.Hidden;
                    else colIdGender.Visibility = Visibility.Visible;
                    break;
                           
                case "chbFst":
                    if (chbFst.IsChecked == false) colFname.Visibility = Visibility.Hidden;
                    else colFname.Visibility = Visibility.Visible; break;
            
                case "chbLst":
                    if (chbLst.IsChecked == false) colLname.Visibility = Visibility.Hidden;
                    else colLname.Visibility = Visibility.Visible; break;
            
                case "chbPtr":
                    if (chbPtr.IsChecked == false) colPatronymic.Visibility = Visibility.Hidden;
                    else colPatronymic.Visibility = Visibility.Visible; break;
            
                case "chbBrt":
                    if (chbBrt.IsChecked == false) colBirthday.Visibility = Visibility.Hidden;
                    else colBirthday.Visibility = Visibility.Visible; break;
            
                case "chbPhn":
                    if (chbPhn.IsChecked == false) colNumber.Visibility = Visibility.Hidden;
                    else colNumber.Visibility = Visibility.Visible; break;
            
                case "chbEml":
                    if (chbEml.IsChecked == false) colEmail.Visibility = Visibility.Hidden;
                    else colEmail.Visibility = Visibility.Visible; break;
                case "chbSpec":
                    if (chbSpec.IsChecked == false) colSpec.Visibility = Visibility.Hidden;
                    else colSpec.Visibility = Visibility.Visible; break;
                case "chbAdres":
                    if (chbAdres.IsChecked == false) colAddress.Visibility = Visibility.Hidden;
                    else colAddress.Visibility = Visibility.Visible; break;
                case "chbAcc":
                    if (chbAcc.IsChecked == false) colAcc.Visibility = Visibility.Hidden;
                    else colAcc.Visibility = Visibility.Visible; break;
                case "chbId":
                    if (chbId.IsChecked == false) colId.Visibility = Visibility.Hidden;
                    else colId.Visibility = Visibility.Visible; break;
            }
        }
    }
}
