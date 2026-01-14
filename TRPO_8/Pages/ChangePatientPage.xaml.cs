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
using System.Collections.ObjectModel;
using TRPO_8.Classs;
using TRPO_8.Data;

namespace TRPO_8.Pages
{
 
    public partial class ChangePatientPage : Page
    {
        public Patient Patient { get; set; }



        public ChangePatientPage(Patient patient)
        {
            InitializeComponent();

            Patient = patient;
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            var bindingExpressions = new[]
            {
        NameTextBox.GetBindingExpression(TextBox.TextProperty),
        LastNameTextBox.GetBindingExpression(TextBox.TextProperty),
        MiddleNameTextBox.GetBindingExpression(TextBox.TextProperty),
        BirthdayTextBox.GetBindingExpression(DatePicker.SelectedDateProperty),
        PhoneTextBox.GetBindingExpression(TextBox.TextProperty)
    };

            foreach (var expr in bindingExpressions)
                expr?.UpdateSource();

            // Проверяем ошибки
            var controls = new Control[]
            {
        NameTextBox,
        LastNameTextBox,
        MiddleNameTextBox,
        PhoneTextBox,
        BirthdayTextBox
            };

            if (controls.Any(c => System.Windows.Controls.Validation.GetHasError(c)))
            {
                MessageBox.Show("Исправьте ошибки", "Ошибка");
                return;
            }

 
            var service = new DataWork();
            service.SavePatientNoId(Patient); 

            MessageBox.Show("Данные обновлены!");
            NavigationService.GoBack();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

      
    }
}
