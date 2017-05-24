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
    

    public partial class LoginPage : Page
    {
        public string UserName;
        public LoginPage()
        {
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
            if (textBoxLogin.Text == "" || passwordBox.Password == "")
            {
                MessageBox.Show("Не задан логин или пароль!", "LOGIN", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                textBoxLogin.Focus();
                return;
            }
            var hPwd = "";
            string bActive = "", bAdmin = "";
            //bool bActive, bAdmin;
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\CRM_Database.mdb";
            OleDbConnection CRM_DB_Conn = new OleDbConnection(connectionString);
            try
            {
                CRM_DB_Conn.Open();
                //MessageBox.Show("Успешно подключено к базе данных:\n" + connectionString);

                string queryString = "";

                queryString = "SELECT Employee_Users.Login, Employee_Users.Hash_Pwd, Employee_Users.Active, Employee_Users.Admin FROM Employee_Users WHERE Employee_Users.Login = '" + textBoxLogin.Text + "'";
                //queryString = "UPDATE Employee_Users SET Hash_Pwd = '" + CalculateHash(passwordBox.Password) + "' WHERE Login = '" + textBoxLogin.Text + "'";

                OleDbCommand Cmd = new OleDbCommand(queryString, CRM_DB_Conn);
                //Cmd.CommandText = "SELECT Employees.FIO, Employees.Position, Employee_Users.Login, Employee_Users.Hash_Pwd, Employee_Users.Active, Employee_Users.Admin " +
                //                  "FROM Employees RIGHT JOIN Employee_Users ON Employees.Empl_ID = Employee_Users.Empl_ID WHERE Employee_Users.Login = '" + textBoxLogin.Text + "'";
                //MessageBox.Show(Cmd.CommandText);
                OleDbDataReader Dr = Cmd.ExecuteReader();
                //MessageBox.Show("Получено Fields = " + Dr.FieldCount + "; Rows = " + Dr.HasRows); // + "; Item[0] = " + Dr.GetValue(0));
                if (Dr.Read())
                {
                    hPwd = Dr["Hash_Pwd"].ToString();
                    bActive = Dr["Active"].ToString();
                    //bActive = Dr.GetBoolean();
                    bAdmin = Dr["Admin"].ToString();
                    //MessageBox.Show("PassWd = " + hPwd + "; Active =" + bActive + "; Admin = " + bAdmin);
                }
                else MessageBox.Show("Нет пользователя: " + textBoxLogin.Text, "Авторизация");
                Dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нет подключения к базе данных:\n" + connectionString + "\n\n" + ex.ToString(), "Application Error");
            }
            finally
            {
                CRM_DB_Conn.Close();
            }

            //if (CalculateHash(passwordBox.Password) == hPwd)
            if (passwordBox.Password == hPwd && hPwd != "")
            {
                //MessageBox.Show("Login/password - CORRECT!!!", "Авторизация");
                if (bActive == "True")
                {
                   // MessageBox.Show("Поздравляю! Вы активный пользователь.", "Проверка на активность");
                    if (bAdmin == "True")
                    {
                       // MessageBox.Show("Вы - Администратор.", "Проверка прав и полномочий");
                        NavigationService.Navigate(KDZ_CRM_Pages.Administrator_Menu);
                        KDZ_CRM_Pages.Administrator_Menu.Go_Out.Focus();
                    }
                    else
                    {
                        //MessageBox.Show("Вы - обычный Пользователь.", "Проверка прав и полномочий");
                        NavigationService.Navigate(KDZ_CRM_Pages.User_Menu);

                        KDZ_CRM_Pages.User_Menu.Go_Out.Focus();

                        UserName = textBoxLogin.Text;


                        //User MyUser;
                        //MyUser = new User();
                        
                        MainWindow.MyUser.Login = UserName;
                        MainWindow.MyUser.User_CompanyList = new List<Company_Protected>();

                        if (MainWindow.MyUser.User_CompanyList != null)
                        {
                            //MessageBox.Show("Companies for " + MainWindow.MyUser.Login);
                            MainWindow.MyUser.User_CompanyList.Add(new Company_Protected() { Comp_Name = "Siemens1", Comp_ID = 1});
                            MainWindow.MyUser.User_CompanyList.Add(new Company_Protected() { Comp_Name = "Siemens2", Comp_ID = 5 });
                            MainWindow.MyUser.User_CompanyList.Add(new Company_Protected() { Comp_Name = "Siemens3" });
                            MainWindow.MyUser.User_CompanyList.Add(new Company_Protected() { Comp_Name = "Siemens4", Comp_ID = 6 });
                            MainWindow.MyUser.User_CompanyList.Add(new Company_Protected() { Comp_Name = "Siemens5" });
                        }
                        else MessageBox.Show("Не создан список компаний!!!");
                    }
                }
                else MessageBox.Show("Сожалею! Вы НЕ активный пользователь.", "Проверка на активность");
            }
            else
            {
                MessageBox.Show("Incorrect login/password", "Авторизация");
                textBoxLogin.Focus();

            }
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Using keyboard handling on the page level
            //if (e.Key == Key.Enter)               buttonLogin_Click(null, null);
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
