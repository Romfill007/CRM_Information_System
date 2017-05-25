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
        bool isChanged = false;

        public Company_Search_User()
        {
            InitializeComponent();
            Company_listView.ItemsSource = MainWindow.MyUser.User_CompanyList;
            //ListViewItem first = (ListViewItem) Company_listView.Items[0];
            ClearControls();
        }

        private void ClearControls()
        {
            Company_listView.ItemsSource = null;
            Company_listView.ItemsSource = MainWindow.MyUser.User_CompanyList;
            Comp_ID.Text = "";
            Comp_Name.Text = "";
            Comp_Adress.Text = "";
            Comp_Contact_Telephone.Text = "";
            Comp_Email.Text = "";
            Comp_Web.Text = "";
            Comp_Additional_Info.Text = "";
            City_Name.Text = "";
            this.isChanged = false;
            //Save_Changes.IsEnabled = false;
        }

        private void Back_Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {

            Company_Protected CurComp = (Company_Protected)Company_listView.SelectedItem;
            if (MessageBox.Show("Будет удалена компания: " + CurComp.Comp_Name + "\nВы уверены?", "Удаление компании", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow.MyUser.User_CompanyList.Remove(CurComp);
                ClearControls();
            }
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            Company_Protected CurComp = (Company_Protected)Company_listView.SelectedItem;
            if (this.isChanged)
            {
                if (MessageBox.Show("В запись о компании: " + CurComp.Comp_Name + "\nвнесены изменения. Вы хотите их сохранить?", "Запись изменена", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    //CurComp.Comp_ID = Comp_ID.Text;
                    CurComp.Comp_Name = Comp_Name.Text;
                    ClearControls();
                }
            }
        }

        private void button_NewComp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MyUser.User_CompanyList.Add(new Company_Protected() { Comp_Name = "Новая компания" });
            ClearControls();
        }

        private void Comp_ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.isChanged = true;
        }

        private void Comp_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.isChanged = true;
        }

        private void Company_listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Company_Protected CurComp = (Company_Protected)Company_listView.SelectedItem;
            if (CurComp != null)
            {
                Comp_ID.Text = CurComp.Comp_ID.ToString();
                Comp_Name.Text = CurComp.Comp_Name;
                this.isChanged = false;
            }
        }
    }
}
