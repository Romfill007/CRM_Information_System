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
    /// Логика взаимодействия для Contact_Search.xaml
    /// </summary>
    public partial class Contact_Search_Admin : Window
    {
        public Contact_Search_Admin()
        {
            InitializeComponent();
        }

        private void Back_Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            KDZ_CRM_MoiseevR.CRM_DatabaseDataSet cRM_DatabaseDataSet = ((KDZ_CRM_MoiseevR.CRM_DatabaseDataSet)(this.FindResource("cRM_DatabaseDataSet")));
            // Загрузить данные в таблицу Contacts. Можно изменить этот код как требуется.
            KDZ_CRM_MoiseevR.CRM_DatabaseDataSetTableAdapters.ContactsTableAdapter cRM_DatabaseDataSetContactsTableAdapter = new KDZ_CRM_MoiseevR.CRM_DatabaseDataSetTableAdapters.ContactsTableAdapter();
            cRM_DatabaseDataSetContactsTableAdapter.Fill(cRM_DatabaseDataSet.Contacts);
            System.Windows.Data.CollectionViewSource contactsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contactsViewSource")));
            contactsViewSource.View.MoveCurrentToFirst();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
