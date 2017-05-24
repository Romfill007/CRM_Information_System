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

namespace KDZ_CRM_MoiseevR
{
    /// <summary>
    /// Логика взаимодействия для User_Menu.xaml
    /// </summary>
    public partial class User_Menu : Page
    {
        public User_Menu()
        {
            InitializeComponent();
        }

        private void Company_Search_Click(object sender, RoutedEventArgs e)
        {
            Company_Search_User Company_Search_User = new Company_Search_User();
            Company_Search_User.Show();
        }

        private void Person_Search_Click(object sender, RoutedEventArgs e)
        {
            Person_Search_User Person_Search_User = new Person_Search_User();
            Person_Search_User.Show();
        }

        private void Contact_Search_Click(object sender, RoutedEventArgs e)
        {
            Contact_Search_User Contact_Search_User = new Contact_Search_User();
            Contact_Search_User.Show();
        }

        private void Go_Out_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
