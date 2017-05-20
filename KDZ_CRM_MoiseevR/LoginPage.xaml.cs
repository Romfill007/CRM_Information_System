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

        private string CalculateHash(string password) {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {

            // Хэш зарегистрированного пользователя должен браться из хранилища
            // данных программы
            var hash = CalculateHash("12");

            if (textBoxLogin.Text == "ef" && CalculateHash(passwordBox.Password) == hash)
            //NavigationService.Navigate(Pages.MainPage);
            {
                MessageBox.Show("Login/password - CORRECT!!!");
                NavigationService.Navigate(KDZ_CRM_Pages.User_Menu);
            }
            else
            {
                MessageBox.Show("Incorrect login/password");
                NavigationService.Navigate(KDZ_CRM_Pages.Administrator_Menu);
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
