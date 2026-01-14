using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainDoctorPage : Page, INotifyPropertyChanged
    {
        DataWork _data = new DataWork();





        private Patient? _patientSelected;
        public Patient? PatientSelected
        {
            get => _patientSelected;
            set
            {
                _patientSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Patient> Patients { get; set; } = new();

        public Doctor CurrentDoctor { get; set; } = new();



        private int _doctorCount;
        public int DoctorCount
        {
            get => _data.CountFileDoctor();
            set
            {
                _doctorCount = value;
                OnPropertyChanged();
            }
        }


        private int _patientCount;
        public int PatientCount
        {
            get => _data.CountFilePatient();
            set
            {
                _patientCount = value;
                OnPropertyChanged();
            }
        }

        public MainDoctorPage(int id)
        {
            InitializeComponent();

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
            if (PatientSelected != null)
            {
                NavigationService.Navigate(new PatientReceptionPage(PatientSelected, CurrentDoctor.IDDoctor));
            }
            else
            {
                MessageBox.Show("Пользователь не выбран", "Ошибка");
                return;
            }
        }

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            if (PatientSelected != null)
            {
                NavigationService.Navigate(new ChangePatientPage(PatientSelected));
            }
            else
            {
                MessageBox.Show("Пользователь не выбран", "Ошибка");
                return;
            }
        }

        private void DeleteInfo_Click(object sender, RoutedEventArgs e)
        {
            if (PatientSelected == null)
            {
                MessageBox.Show("Выберите пациента", "Ошибка");
                return;
            }

            bool confirmDelete = MessageBox.Show("Вы действительно хотите удалить пациента?", "Подтвержедние удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
            
            if (confirmDelete)
            {
                var _data = new DataWork();
                _data.DeletePatient(PatientSelected.IDPatient);

                Patients.Remove(PatientSelected);
                MessageBox.Show("Пациент удален", "Успех");
            }
        }


      



        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
