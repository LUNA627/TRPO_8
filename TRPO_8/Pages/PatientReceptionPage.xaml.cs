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
    /// Логика взаимодействия для PatientReceptionPage.xaml
    /// </summary>
    public partial class PatientReceptionPage : Page
    {
        public Patient Patient {  get; set; }
        public int CurrentDoctorId { get; set; }
        public Appointment CurrentAppointment { get; set; } = new Appointment();


        public PatientReceptionPage(Patient patient, int doctorId)
        {
            InitializeComponent();
            Patient = patient;
            CurrentDoctorId = doctorId;
            CurrentAppointment.DoctorId = doctorId;

            DataContext = this;
        }

        private void GoBackPatient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ChangePatient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangePatientPage(Patient));
        }

        private void SaveAppointment_Click(object sender, RoutedEventArgs e)
        {
            var bindingExpressions = new[]
            {
                DiagnosisTextBox.GetBindingExpression(TextBox.TextProperty),
                RecomendationsTextBox.GetBindingExpression(TextBox.TextProperty)
            };

            foreach (var expr in bindingExpressions)
            {
                expr?.UpdateSource();
            }

            var textBoxes = new[]
            {
              DiagnosisTextBox,
              RecomendationsTextBox
            };

            foreach (var textBox in textBoxes)
            {
                if (System.Windows.Controls.Validation.GetHasError(textBox))
                {
                    MessageBox.Show("Заполните поля корректно", "Ошибка");
                    return;
                }
            }

            var newAppointment = new Appointment
            {
                Date = DateTime.Today.ToString("dd.MM.yyyy"),
                DoctorId = CurrentDoctorId,
                Diagnosis = CurrentAppointment.Diagnosis,
                Recomendations = CurrentAppointment.Recomendations
            };


            Patient.AppointmentStories.Add(newAppointment);

            var _data = new DataWork();
            _data.SavePatientNoId(Patient);

          

            MessageBox.Show("Приём сохранён!", "Успех");
        }

     
    }
}
