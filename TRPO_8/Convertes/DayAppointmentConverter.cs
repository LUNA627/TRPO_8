using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TRPO_8.Classs;

namespace TRPO_8.Convertes
{
    internal class DayAppointmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<Appointment> appointments && appointments != null)
            {
                if (!appointments.Any())
                    return "Первый приём";

                var lastAppointment = appointments.OrderByDescending(a => a.DateAppointment).FirstOrDefault();

                // Проверка на DateTime.MinValue
                if (lastAppointment?.DateAppointment == DateTime.MinValue)
                    return "Некорректная дата";

                var today = DateTime.Today;
                var days = (today - lastAppointment.DateAppointment.Date).Days;

                return $"{days} дней";
            }

            return "Первый приём";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
