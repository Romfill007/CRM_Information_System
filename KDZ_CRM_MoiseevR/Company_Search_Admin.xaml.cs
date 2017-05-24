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
    /// Логика взаимодействия для Company_Search.xaml
    /// </summary>
    public partial class Company_Search_Admin : Window
    {
        public Company_Search_Admin()
        {
            InitializeComponent();
        }

        private void Back_Menu_Click(object sender, RoutedEventArgs e)
        {
            //FrameCompanySearch.Navigate(User_Menu);
            this.Close();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            KDZ_CRM_MoiseevR.CRM_DatabaseDataSet cRM_DatabaseDataSet = ((KDZ_CRM_MoiseevR.CRM_DatabaseDataSet)(this.FindResource("cRM_DatabaseDataSet")));
            // Загрузить данные в таблицу Company_Protected. Можно изменить этот код как требуется.
            KDZ_CRM_MoiseevR.CRM_DatabaseDataSetTableAdapters.Company_ProtectedTableAdapter cRM_DatabaseDataSetCompany_ProtectedTableAdapter = new KDZ_CRM_MoiseevR.CRM_DatabaseDataSetTableAdapters.Company_ProtectedTableAdapter();
            cRM_DatabaseDataSetCompany_ProtectedTableAdapter.Fill(cRM_DatabaseDataSet.Company_Protected);
            System.Windows.Data.CollectionViewSource company_ProtectedViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("company_ProtectedViewSource")));
            company_ProtectedViewSource.View.MoveCurrentToFirst();
        }
    }
}
