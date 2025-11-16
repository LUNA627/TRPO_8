using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MainDoctorPage.xaml
    /// </summary>
    public partial class MainDoctorPage : Page
    {
        public Patient? PatientSeleced { get; set; }
        public ObservableCollection<Patient> Patients { get; set; } = new();

        public Doctor CurrentDoctor { get; set; } = new();


        public MainDoctorPage(int id)
        {
            InitializeComponent();

            var _data = new DataWork();
            CurrentDoctor = _data.GetDoctorById(id);

            var allPatients = _data.LoadAllPatients();
            foreach (var patient in allPatients)
            {
                Patients.Add(patient);
            }
            DataContext = this;
        }

        private void CreatNewPatint_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateNewPatientPage(CurrentDoctor.IDDoctor, Patients));
        }

        private void StartAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (PatientSeleced != null)
            {
                NavigationService.Navigate(new PatientReceptionPage(PatientSeleced, CurrentDoctor.IDDoctor));
            }
            else
            {
                MessageBox.Show("Пользователь не выбран");
            }
        }

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            if (PatientSeleced != null)
            {
                NavigationService.Navigate(new ChangePatientPage(PatientSeleced));
            }
            else
            {
                MessageBox.Show("Пользователь не выбран");
            }
        }
    }
}
