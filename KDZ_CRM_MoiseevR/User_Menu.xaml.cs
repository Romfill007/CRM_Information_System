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
using System.IO;
using System.Xml.Serialization;

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
            Company_Search_User Company_Search_User = new Company_Search_User();
            Company_Search_User.Show();
        }

        
        private void Go_Out_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void button_Restore_Click(object sender, RoutedEventArgs e)
        {
            string sFileName = "CRM.xml";
            using (var fs = new FileStream(sFileName, FileMode.Open))
            {
                if (fs == null)
                {
                    MessageBox.Show("Файл " + sFileName + "\n не найден!!!", "Открытие файла");
                }
                else
                {
                    XmlSerializer xml = new XmlSerializer(typeof(User));
                    MainWindow.MyUser = (User)xml.Deserialize(fs);
                    MessageBox.Show("Файл " + sFileName + "\n загружен!!!");

                }
            }

        }

        private void button_SaveAll_Click(object sender, RoutedEventArgs e)
        {
            string sFileName = "CRM.xml";
            using (var fs = new FileStream(sFileName, FileMode.Create))
            {
                if (fs == null)
                {
                    MessageBox.Show("Файл " + sFileName + "\n не создан!!!", "Создание файла");
                }
                else
                {
                    XmlSerializer xml = new XmlSerializer(typeof(User));
                    xml.Serialize(fs, MainWindow.MyUser);
                    MessageBox.Show("Файл " + sFileName + "\n сохранен!!!");

                }
            }
        }
    }
}
