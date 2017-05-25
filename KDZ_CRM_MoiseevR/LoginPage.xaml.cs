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

        private int Company_From_DB (OleDbConnection CRM_DB_Conn, string sLogin)
        {
            int iReturn = 0;
            try
            {
                CRM_DB_Conn.Open();
                //MessageBox.Show("Успешно подключено к базе данных:\n" + connectionString);

                string queryString = "";

                queryString = "SELECT Company_Protected.Comp_ID,  Company_Protected.Comp_Name, City.City_Name, Company_Protected.Comp_Adress, Company_Protected.Comp_Website, Company_Protected.Comp_Email, Company_Protected.Comp_Contact_Telephone, Company_Protected.Comp_Additional_Info, " +
                    "Company_Protected.Comp_ID_City FROM City INNER JOIN Company_Protected ON City.City_ID = Company_Protected.Comp_ID_City";
                    //" '" + sLogin + "'";

                OleDbCommand Cmd = new OleDbCommand(queryString, CRM_DB_Conn);
                //MessageBox.Show(Cmd.CommandText);
                OleDbDataReader Dr = Cmd.ExecuteReader();
                //MessageBox.Show("Получено Fields = " + Dr.FieldCount + "; Rows = " + Dr.HasRows); 
                while (Dr.Read())
                {
                    Company_Protected Comp = new Company_Protected(); //= MainWindow.MyUser.User_CompanyList.Last();
                        Comp.Comp_Name = Dr["Comp_Name"].ToString();
                        Comp.Comp_Website = Dr["Comp_Website"].ToString();
                        Comp.Comp_Adress = Dr["Comp_Adress"].ToString();
                        Comp.Comp_Contact_Telephone = Dr["Comp_Contact_Telephone"].ToString();
                        Comp.City_Name = Dr["City_Name"].ToString();
                        Comp.Comp_Email = Dr["Comp_Email"].ToString();
                        Comp.Comp_Additional_Info = Dr["Comp_Additional_Info"].ToString();
                        Comp.Comp_ID_City = Dr["Comp_ID_City"].ToString();
                        Comp.Comp_ID = Dr["Comp_ID"].ToString();

                        Comp.Company_PersonList = new List<Person>();
                        Comp.Company_ContactList = new List<Contact>();
                        Comp.Company_EquipmentList = new List<Equipment>();
                     MainWindow.MyUser.User_CompanyList.Add(Comp); 
             
                    int iRes = Person_From_DB(CRM_DB_Conn, Comp);
                    if ( iRes == 0) MessageBox.Show ("У компании\n" + Comp.Comp_Name + "\n не найдены контактные лица" );
                    iReturn++;
                }
                Dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нет подключения к базе данных:\n\n\n" + ex.ToString(), "Application Error");

            }
            finally
            {
                CRM_DB_Conn.Close();
            }
            return iReturn;
        }

        private int Person_From_DB(OleDbConnection CRM_DB_Conn, Company_Protected Comp)
        {
            int iReturn = 0;
            try
            {
                //CRM_DB_Conn.Open();
                //MessageBox.Show("Успешно подключено к базе данных:\n" + connectionString);

                string queryString = "";

                queryString = "SELECT Person.Person_ID, Person.Person_FIO, Person.Person_Position, Person.Person_Company_ID " +
                                " FROM Person WHERE Person_Company_ID = " + Comp.Comp_ID.ToString();

                OleDbCommand Cmd = new OleDbCommand(queryString, CRM_DB_Conn);
                //MessageBox.Show(Cmd.CommandText);
                OleDbDataReader Dr = Cmd.ExecuteReader();
                //MessageBox.Show("Получено Fields = " + Dr.FieldCount + "; Rows = " + Dr.HasRows); 
                while (Dr.Read())
                {
                    Comp.Company_PersonList.Add(new Person()
                    {
                        Person_ID = Dr["Person_ID"].ToString(),
                        Person_FIO = Dr["Person_FIO"].ToString(),
                        Person_Position = Dr["Person_Position"].ToString(),
                        Comp_ID = Dr["Person_Company_ID"].ToString()
                    });
                    //MessageBox.Show("Получено Person_ID = " + Dr["Person_ID"].ToString() + "; Person_FIO = " + Dr["Person_FIO"].ToString()); 
                    iReturn++;
                }
                Dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нет подключения к базе данных:\n\n\n" + ex.ToString(), "Application Error");

            }
            finally
            {
                //CRM_DB_Conn.Close();
            }
            return iReturn;
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
                        
                        MainWindow.MyUser.Login = UserName;
                        MainWindow.MyUser.User_CompanyList = new List<Company_Protected>();

                        int iComp = Company_From_DB(CRM_DB_Conn, UserName);
                        if (  iComp  > 0)
                        {
                            MessageBox.Show("Получено " + iComp + " компаний!!!");

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
