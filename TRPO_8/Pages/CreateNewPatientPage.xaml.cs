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
    /// Логика взаимодействия для CreateNewPatientPage.xaml
    /// </summary>
    public partial class CreateNewPatientPage : Page
    {

        public ObservableCollection<Patient> _patients;


        public Patient _patient = new Patient();

        public CreateNewPatientPage(int doctorId, ObservableCollection<Patient> patients)
        {
            InitializeComponent();
            _patients = patients;
            DataContext = _patient;
        }

        private void SaveNewPatint_Click(object sender, RoutedEventArgs e)
        {

            var bindingExpressions = new[]
            {
                LastNameTextBox.GetBindingExpression(TextBox.TextProperty),
                NameTextBox.GetBindingExpression(TextBox.TextProperty),
                MiddleNameTextBox.GetBindingExpression(TextBox.TextProperty),
                PhoneTextBox.GetBindingExpression(TextBox.TextProperty),

            };

            foreach (var expr in bindingExpressions)
            {
                expr?.UpdateSource();
            }

            var textBoxes = new[]
            {
              LastNameTextBox,
              NameTextBox,
              MiddleNameTextBox,
              PhoneTextBox
            };

            foreach (var textBox in textBoxes)
            {
                if (System.Windows.Controls.Validation.GetHasError(textBox))
                {
                    MessageBox.Show("Заполните поля корректно", "Ошибка");
                    return;
                }
            }


            var _data = new DataWork();
            _data.SavePatient(_patient);
            _patients.Add(_patient);
            MessageBox.Show("Пациент успешно создан!", "Успех");

            _data.CountFilePatient();
            NavigationService.GoBack();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
