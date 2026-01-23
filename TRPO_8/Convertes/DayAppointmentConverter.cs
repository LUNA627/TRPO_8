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
            if (value is int days)
            {
                if (days == -1) return "Первый приём";
                if (days == 0) return "Сегодня";
                if (days == 1) return "Вчера";
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
