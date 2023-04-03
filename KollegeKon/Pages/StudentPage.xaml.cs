using KollegeKon.ClassHelper;
using KollegeKon.DB;
using KollegeKon.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            cmbGroup.DisplayMemberPath = "Name";
            cmbGroup.ItemsSource = context.Group.ToList();



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
                catch (Exception ex)
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgStudent.ItemsSource = context.Student.ToList().Where(i => i.Fname.Contains(Fname.Text));
        }

        private void Lname_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgStudent.ItemsSource = context.Student.ToList().Where(i => i.Lname.Contains(Lname.Text));
        }

        private void cmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            dgStudent.ItemsSource = context.Student.ToList().Where(i => i.IdGroup == (cmbGroup.SelectedItem as Group).Id);
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
                    if (chbGroup.IsChecked == false) colIdGroup.Visibility = Visibility.Hidden;
                    else colIdGroup.Visibility = Visibility.Visible; break;
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
