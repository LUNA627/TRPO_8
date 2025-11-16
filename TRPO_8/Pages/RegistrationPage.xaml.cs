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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public string _Name { get; set; } = "";
        public string _LastName { get; set; } = "";
        public string _MiddleName { get; set; } = "";
        public string _Specialisation { get; set; } = "";
        public string _Password { get; set; } = "";
        public string _RepeatDoctor { get; set; } = "";

        public RegistrationPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveNewDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_Name) ||
               string.IsNullOrWhiteSpace(_LastName) ||
               string.IsNullOrWhiteSpace(_MiddleName) ||
               string.IsNullOrWhiteSpace(_Specialisation))
            {
                MessageBox.Show("Все поля обязательны для заполнения.");
                return;
            }

            var doctor = new Doctor
            {
                NameDoctor = _Name,
                LastNameDoctor = _LastName,
                MiddleNameDoctor = _MiddleName,
                SpecialisationDoctor = _Specialisation,
                PasswordDoctor = _Password,
                RepeatDoctor = _RepeatDoctor,
            };

            try
            {
                var service = new DataWork();
                service.SaveDoctor(doctor);
                MessageBox.Show($"Доктор успешно зарегистрирован!\nID: {doctor.IDDoctor}", "Успех");
                NavigationService.Navigate(new MainDoctorPage(doctor.IDDoctor));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
