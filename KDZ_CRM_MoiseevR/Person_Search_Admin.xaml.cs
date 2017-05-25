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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            KDZ_CRM_MoiseevR.CRM_DatabaseDataSet cRM_DatabaseDataSet = ((KDZ_CRM_MoiseevR.CRM_DatabaseDataSet)(this.FindResource("cRM_DatabaseDataSet")));
            // Загрузить данные в таблицу Persons. Можно изменить этот код как требуется.
            KDZ_CRM_MoiseevR.CRM_DatabaseDataSetTableAdapters.PersonsTableAdapter cRM_DatabaseDataSetPersonsTableAdapter = new KDZ_CRM_MoiseevR.CRM_DatabaseDataSetTableAdapters.PersonsTableAdapter();
            cRM_DatabaseDataSetPersonsTableAdapter.Fill(cRM_DatabaseDataSet.Persons);
            System.Windows.Data.CollectionViewSource personsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personsViewSource")));
            personsViewSource.View.MoveCurrentToFirst();
        }
    }
}
