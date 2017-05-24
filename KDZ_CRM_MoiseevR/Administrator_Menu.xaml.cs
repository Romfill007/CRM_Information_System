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
    /// Логика взаимодействия для Administrator_Menu.xaml
    /// </summary>
    public partial class Administrator_Menu : Page
    {
        public Administrator_Menu()
        {
            InitializeComponent();
        }

        private void Company_Search_Click(object sender, RoutedEventArgs e)
        {
            Company_Search_Admin Company_Search_Admin = new Company_Search_Admin();
            Company_Search_Admin.Show();
        }

        private void Person_Search_Click(object sender, RoutedEventArgs e)
        {
            Person_Search_Admin Person_Search_Admin = new Person_Search_Admin();
            Person_Search_Admin.Show();
        }

        private void Contact_Search_Click(object sender, RoutedEventArgs e)
        {
            Contact_Search_Admin Contact_Search_Admin = new Contact_Search_Admin();
            Contact_Search_Admin.Show();
        }

        private void User_Search_Click(object sender, RoutedEventArgs e)
        {
            User_Search User_Search = new User_Search();
            User_Search.Show();
        }

        private void References_Click(object sender, RoutedEventArgs e)
        {
            References References = new References();
            References.Show();
        }

        private void Protocol_Click(object sender, RoutedEventArgs e)
        {
            Protocol Protocol = new Protocol();
            Protocol.Show();
        }

        private void Go_Out_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
