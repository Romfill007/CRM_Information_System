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

namespace FrameDemo {
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page {
        List<Person> _people = new List<Person>();

        public MainPage() {
            InitializeComponent();
        }

        public void NewPersonAdded(Person person) {
            _people.Add(person);
            listBoxPeople.ItemsSource = null;
            listBoxPeople.ItemsSource = _people;
        }

        private void buttonNewPerson_Click(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(Pages.AddPersonPage);
        }
    }
}
