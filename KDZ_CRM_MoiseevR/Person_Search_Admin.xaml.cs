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
    /// Логика взаимодействия для Person_Search.xaml
    /// </summary>
    public partial class Person_Search_Admin : Window
    {
        public Person_Search_Admin()
        {
            InitializeComponent();
        }

        private void Back_Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
