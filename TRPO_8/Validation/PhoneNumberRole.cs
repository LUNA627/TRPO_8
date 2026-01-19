using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO_8.Validation
{
    internal class PhoneNumberRole : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            var digitOnly = new string(input.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(digitOnly))
            {
                return new ValidationResult(false, "Введите корректный номер телефона");
            }

            if (digitOnly.Length > 11)
            {
                return new ValidationResult(false, "Номер должен содержать 11 цифр");
            }

            if (digitOnly.Length != 11 && digitOnly[0] != '8' && digitOnly[0] != '7')
            {
                return new ValidationResult(false, "Номер должен начинаться с 8 или 7");
            }
            return ValidationResult.ValidResult;
        }
    }
}
