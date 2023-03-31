using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using static KollegeKon.ClassHelper.EFClass;

namespace KollegeKon.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            string text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            for (int i = 0; i < 5; ++i)
            {
                text += ALF[rnd.Next(ALF.Length)];
            }
            Capcha.Text = text;
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var authUser = context.Account.ToList()
                .Where(i => i.Login == tbLogin.Text && i.Password == pbPass.Password)
                .FirstOrDefault();
            if (authUser != null)
            {
                if (tBCapcha.Text == Capcha.Text)
                {
                    if (authUser.IsActive != false)
                    {
                        string connectionString = @"Data Source=224-1\SQLEXPRESS; Initial Catalog=Kollege; Integrated Security=True";
                        using(SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sqlExperssion = "SELECT Id FROM Student WHERE IdAccount = (SELECT Id FROM[Account] WHERE Login='" + tbLogin.Text + "' )";
                            SqlCommand command = new SqlCommand(sqlExperssion, connection);
                            if(command.ExecuteScalar()!=null)
                            {
                                MainWindow main = new MainWindow();
                                main.Show();
                                this.Close();
                            }
                            string sqlExperssion2 = "SELECT Id FROM Teacher WHERE IdAccount = (SELECT Id FROM[Account] WHERE Login='" + tbLogin.Text + "' )";
                            SqlCommand command2 = new SqlCommand(sqlExperssion2, connection);
                            if (command2.ExecuteScalar() != null)
                            {
                                RegistrationWindow reg = new RegistrationWindow();
                                reg.Show();
                                this.Close();
                            }
                        }
                       
                    }
                }
                else
                {
                    MessageBox.Show("Неверная введена капча");
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void genCapcha_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            string text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            for (int i = 0; i < 5; ++i)
            {
                text += ALF[rnd.Next(ALF.Length)];
            }
            Capcha.Text = text;


        }

        private void tblReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow reg = new RegistrationWindow();
            this.Close();
            reg.Show();
        }
    }
}
