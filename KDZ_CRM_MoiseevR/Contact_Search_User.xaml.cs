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
using System.Windows.Shapes;

namespace KDZ_CRM_MoiseevR
{
    /// <summary>
    /// Логика взаимодействия для Contact_Search_User.xaml
    /// </summary>
    public partial class Contact_Search_User : Window
    {
        public Contact_Search_User()
        {
            InitializeComponent();
        }

        private void Back_Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
