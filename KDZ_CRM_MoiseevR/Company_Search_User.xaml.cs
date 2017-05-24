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
    /// Логика взаимодействия для Company_Search_User.xaml
    /// </summary>
    public partial class Company_Search_User : Window
    {
        public Company_Search_User()
        {
            InitializeComponent();
            Company_listView.ItemsSource = MainWindow.MyUser.User_CompanyList;
            //ListViewItem first = (ListViewItem) Company_listView.Items[0];
        }   

        private void Back_Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Company_listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Company_Protected CurComp = (Company_Protected) Company_listView.SelectedItem;
            if (CurComp != null) {
                Comp_ID.Text = CurComp.Comp_ID.ToString();
                Comp_Name.Text = CurComp.Comp_Name;
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {

           Company_Protected CurComp = (Company_Protected) Company_listView.SelectedItem;
           MainWindow.MyUser.User_CompanyList.Remove(CurComp);
            //List <Company_Protected> User_CompanyList = (List<Company_Protected>) Company_listView.ItemsSource;
            // Company_listView.Items.Remove(CurComp);
            Company_listView.ItemsSource = null;
            Company_listView.ItemsSource = MainWindow.MyUser.User_CompanyList;

        }
    }
}
