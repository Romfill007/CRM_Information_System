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
            Company_Search Company_Search = new Company_Search();
            Company_Search.Show();
        }

        private void Person_Search_Click(object sender, RoutedEventArgs e)
        {
            Person_Search Person_Search = new Person_Search();
            Person_Search.Show();
        }

        private void Contact_Search_Click(object sender, RoutedEventArgs e)
        {
            Contact_Search Contact_Search = new Contact_Search();
            Contact_Search.Show();
        }

        private void Go_Out_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
