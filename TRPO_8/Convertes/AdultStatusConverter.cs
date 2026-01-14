using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TRPO_8.Convertes
{
    internal class AdultStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targertType, object paremeter, CultureInfo culture)
        {
            if (value is DateTime birthDate)
            {
                var age = DateTime.Today.Year - birthDate.Year;

                if (birthDate.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }

                return age >= 18 ? "совершеннолетний" : "несовершеннолетний";
            }

            return "";
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
