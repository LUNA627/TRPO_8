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
using TRPO_8.Classs;
using TRPO_8.Data;

namespace TRPO_8.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    /// 

    public partial class LoginPage : Page
    {
        DataWork _dw = new DataWork();
        public int DoctorId { get; set; } = 0;
        public string Password { get; set; } = "";

        public LoginPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void LoginDoctor_Click(object sender, RoutedEventArgs e)
        {


            if (_dw.CheckDoctorLogin(DoctorId, Password))
            {
                NavigationService.Navigate(new MainDoctorPage(DoctorId));
            }
            else
            {
                MessageBox.Show("Неверный Id или пароль");
            }
        }

        private void RegistrationDoctor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
