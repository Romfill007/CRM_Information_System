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
using System.Data;
using System.Data.OleDb;
using System.Xml.Serialization;


namespace KDZ_CRM_MoiseevR
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page {
        public LoginPage() {
            InitializeComponent();
            // При загрузке страницы передаем фокус первому текстбоксу, чтобы
            // сразу можно было вводить имя пользователя
            textBoxLogin.Focus();
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {

            // Хэш зарегистрированного пользователя должен браться из хранилища
            // данных программы
            var hPwd = "";
            string bActive = "", bAdmin = "";
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\CRM_Database.mdb";
            OleDbConnection CRM_DB_Conn = new OleDbConnection(connectionString);
            try
            {
                CRM_DB_Conn.Open();
                MessageBox.Show("Подключено к базе данных:" + connectionString);
                OleDbCommand Cmd = CRM_DB_Conn.CreateCommand();
                /*
                Cmd.CommandText = "UPDATE Employee_Users SET Hash_Pwd = '" + CalculateHash(passwordBox.Password) + "' WHERE Login = '" + textBoxLogin.Text + "'";
                MessageBox.Show(Cmd.CommandText);
                int iRes = Cmd.ExecuteNonQuery();
                if (iRes < 1)
                {
                    MessageBox.Show("Non Update for " + Cmd.CommandText);
                }
                else MessageBox.Show("Result = " + iRes + " OK!!! " + Cmd.CommandText);
                //CRM_DB_Conn.Close();
                //CRM_DB_Conn.Open();
                */
                Cmd.CommandText = "SELECT Hash_Pwd, Active, Admin FROM Employee_Users WHERE Login = '" + textBoxLogin.Text + "'";
                MessageBox.Show(Cmd.CommandText);
                OleDbDataReader Dr = Cmd.ExecuteReader();
                while (Dr.Read())
                {
                    MessageBox.Show(Dr[0].ToString() + " Activ =" + Dr[1].ToString() + " Admin = " + Dr[2].ToString());
                    hPwd = Dr[0].ToString();
                    bActive = Dr[1].ToString();
                    bAdmin = Dr[2].ToString();
                }
                Dr.Close();
            }
            catch
            {
                MessageBox.Show("Нет подключения к базе данных:" + connectionString);
            }
            finally
            {
                CRM_DB_Conn.Close();
            }

            //if (CalculateHash(passwordBox.Password) == hPwd)
            if (passwordBox.Password == hPwd)
            {
                MessageBox.Show("Login/password - CORRECT!!!");
                if (bAdmin == "True")
                {
                    MessageBox.Show("Поздравляю! Вы Администратор.");
                    NavigationService.Navigate(KDZ_CRM_Pages.Administrator_Menu);
                }
                else {
                    MessageBox.Show("Вы - Пользователь.");
                    NavigationService.Navigate(KDZ_CRM_Pages.User_Menu);
                }
            }
            else
            {
                MessageBox.Show("Incorrect login/password");
            }
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Using keyboard handling on the page level
            if (e.Key == Key.Enter)
                buttonLogin_Click(null, null);
        }
    }
}
