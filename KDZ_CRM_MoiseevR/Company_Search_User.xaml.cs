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
            //ListViewItem first = (ListViewItem) Company_listView.Items[0];
            ClearControls();
        }   

        private void Back_Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearControls ()
        {
            Company_listView.ItemsSource = null;
            Company_listView.ItemsSource = MainWindow.MyUser.User_CompanyList;
            Comp_ID.Text = "";
            Comp_Name.Text = "";
            Comp_Adress.Text = "";
            Comp_Contact_Telephone.Text = "";
            Comp_Email.Text = "";
            Comp_Website.Text = "";
            Comp_Additional_Info.Text = "";
            City_Name.Text = "";
            this.isChanged = false;
            //Save_Changes.IsEnabled = false;
        }
        
        private void Company_listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Company_listView.SelectedItem != null)
            {
               Company_Protected CurComp = (Company_Protected) Company_listView.SelectedItem;
               Comp_ID.Text = CurComp.Comp_ID; // Код компании-клиента
               Comp_Name.Text = CurComp.Comp_Name; // Наименование компании-клиента
               Comp_Website.Text = CurComp.Comp_Website; // Website компании-клиента
               Comp_Email.Text = CurComp.Comp_Email;
                //Comp_ID_City.Text = Comp_ID_City.Comp_Email; // код города
               City_Name.Text = CurComp.City_Name;//наименование города
               Comp_Adress.Text = CurComp.Comp_Adress; // адрес компании
               Comp_Contact_Telephone.Text = CurComp.Comp_Contact_Telephone;//контактный телефон
               Comp_Additional_Info.Text = CurComp.Comp_Additional_Info;// краткое описание

                this.isChanged = false;
            }
            //else MessageBox.Show("No item selected !");
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {

           Company_Protected CurComp = (Company_Protected) Company_listView.SelectedItem;
            if (MessageBox.Show("Будет удалена компания: " + CurComp.Comp_Name + "\nВы уверены?", "Удаление компании", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow.MyUser.User_CompanyList.Remove(CurComp);
                ClearControls();
            }

        }

        private void Comp_ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.isChanged = true;
        }

        private void Comp_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.isChanged = true;
            //Save_Changes.IsEnabled = true;
        }

        private void Save_Changes_Click(object sender, RoutedEventArgs e)
        {
                /* Company_Protected CurComp = (Company_Protected)Company_listView.SelectedItem;
            if (this.isChanged)
            {
                if (MessageBox.Show("В запись о компании: " + CurComp.Comp_Name + "\nвнесены изменения. Вы хотите их сохранить?", "Запись изменена", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    CurComp.Comp_ID = Comp_ID.Text;
                    CurComp.Comp_Name = Comp_Name.Text;
                    CurComp.City_Name = City_Name.Text;//наименование города
                    CurComp.Comp_Adress = Comp_Adress.Text; // адрес компании
                    CurComp.Comp_Contact_Telephone = Comp_Contact_Telephone.Text;//контактный телефон
                    CurComp.Comp_Email = Comp_Email.Text;
                    CurComp.Comp_Additional_Info = Comp_Additional_Info.Text;// краткое описание
                    ClearControls();
                }
            }*/
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            Company_Protected CurComp = (Company_Protected)Company_listView.SelectedItem;
            if (this.isChanged)
            {
                if (MessageBox.Show("В запись о компании: " + CurComp.Comp_Name + "\nвнесены изменения. Вы хотите их сохранить?", "Запись изменена", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    CurComp.Comp_ID = Comp_ID.Text;
                    CurComp.Comp_Name = Comp_Name.Text;
                    CurComp.City_Name = City_Name.Text;//наименование города
                    CurComp.Comp_Adress = Comp_Adress.Text; // адрес компании
                    CurComp.Comp_Contact_Telephone = Comp_Contact_Telephone.Text;//контактный телефон
                    CurComp.Comp_Email = Comp_Email.Text;
                    CurComp.Comp_Additional_Info = Comp_Additional_Info.Text;// краткое описание
                    ClearControls();
                }
            }
        }

        private void button_NewComp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MyUser.User_CompanyList.Add(new Company_Protected() { Comp_Name = "Новая компания" });
                    ClearControls();
        }

        private void Comp_Additional_Info_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.isChanged = true;
        }

        private void Comp_Contact_Telephone_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.isChanged = true;

        }

        private void Comp_Adress_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.isChanged = true;

        }

        private void City_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.isChanged = true;

        }

        private void Comp_Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.isChanged = true;

        }

        private void Comp_Website_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.isChanged = true;

        }

        private void button_Person_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MyUser.CurComp = (Company_Protected)Company_listView.SelectedItem;
            Person_Search_User Person_Search_User = new Person_Search_User();
            Person_Search_User.Show();
        }
    }
}
