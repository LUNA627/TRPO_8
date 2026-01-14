using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO_8.Validation
{
    internal class DateTimeRole : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
           DateTime selectedDate = (DateTime)value;

            if  (selectedDate > DateTime.Today)
            {
                return new ValidationResult(false, "Дата рождения не может быть в будущем");
            }

            if (selectedDate < DateTime.Today.AddYears(-120))
            {
                return new ValidationResult(false, "Дата рождения не может быть раньше 120 лет назад");
            }


            return ValidationResult.ValidResult;

        }
    }
}
