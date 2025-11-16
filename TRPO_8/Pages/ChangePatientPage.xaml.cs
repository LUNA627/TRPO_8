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
    /// Логика взаимодействия для ChangePatientPage.xaml
    /// </summary>
    public partial class ChangePatientPage : Page
    {
        public Patient _originalPatient;
        public Patient Patient { get; set; }



        public ChangePatientPage(Patient patient)
        {
            InitializeComponent();
            _originalPatient = patient;

            Patient = new Patient
            {
                IDPatient = patient.IDPatient,
                NamePatient = patient.NamePatient,
                LastNamePatient = patient.LastNamePatient,
                MiddleNamePatient = patient.MiddleNamePatient,
                BirthdayPatient = patient.BirthdayPatient,
                PhonePatient = patient.PhonePatient,
                AppointmentStories = new List<Appointment>(patient.AppointmentStories)
            };
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _originalPatient.NamePatient = Patient.NamePatient;
            _originalPatient.LastNamePatient = Patient.LastNamePatient;
            _originalPatient.MiddleNamePatient = Patient.MiddleNamePatient;
            _originalPatient.BirthdayPatient = Patient.BirthdayPatient;
            _originalPatient.PhonePatient = Patient.PhonePatient;
             
            var _data = new DataWork();
            _data.SavePatientNoId(_originalPatient);
            MessageBox.Show("Данные пациента обновлены!", "Успех");
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
