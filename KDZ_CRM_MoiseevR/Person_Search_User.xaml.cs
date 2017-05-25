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
    /// Логика взаимодействия для Person_Search_User.xaml
    /// </summary>
    public partial class Person_Search_User : Window
    {
        bool isChanged = false;

        public Person_Search_User()
        {
            InitializeComponent();
            ClearControls();

        }

        private void Back_Menu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_NewPers_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MyUser.CurComp.Company_PersonList.Add(new Person() { Person_FIO = "Новое контактное лицо" });
            ClearControls();

        }

        private void listView_Person_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView_Person.SelectedItem != null)
            {
                Person CurPers = (Person)listView_Person.SelectedItem;
                textBox_ID_Pers.Text = CurPers.Person_ID; 
                textBox_FIO_Pers.Text = CurPers.Person_FIO; 
                textBox_PersPos.Text = CurPers.Person_Position; 
                
                this.isChanged = false;
            }
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            Person CurPers = (Person) listView_Person.SelectedItem;
            if (this.isChanged)
            {
                if (MessageBox.Show("В запись о контактном лице: " + CurPers.Person_FIO + "\nвнесены изменения. Вы хотите их сохранить?", "Запись изменена", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    CurPers.Person_ID = textBox_ID_Pers.Text;
                    CurPers.Person_FIO = textBox_FIO_Pers.Text;
                    CurPers.Person_Position = textBox_PersPos.Text;
                    
                    ClearControls();
                }
            }
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Person CurPers = (Person) listView_Person.SelectedItem;
            if (MessageBox.Show("Будет удалён: " + CurPers.Person_FIO + "\nВы уверены?", "Удаление контактного лица", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MainWindow.MyUser.CurComp.Company_PersonList.Remove(CurPers);
                ClearControls();
            }
        }
        private void ClearControls()
        {
            listView_Person.ItemsSource = null;
            listView_Person.ItemsSource = MainWindow.MyUser.CurComp.Company_PersonList;
            textBox_ID_Pers.Text = "";
            textBox_FIO_Pers.Text = "";
            textBox_PersPos.Text = "";
            
            this.isChanged = false;
            //Save_Changes.IsEnabled = false;
        }

        private void textBox_ID_Pers_TextChanged(object sender, TextChangedEventArgs e)
        {
            isChanged = true;
        }

        private void textBox_FIO_Pers_TextChanged(object sender, TextChangedEventArgs e)
        {
            isChanged = true;
        }

        private void textBox_PersPos_TextChanged(object sender, TextChangedEventArgs e)
        {
            isChanged = true;
        }
    }
}
