using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO_8.Validation
{
    class CountSimvolRule : ValidationRule
    {
        public override ValidationResult Validate (object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input.Length < 8)
            {
                return new ValidationResult(false, "Минимальная длина 8 символов");
            }
            else if (input.Length > 20)
            {
                return new ValidationResult(false, "Максимальная длина 20 символов");
            }

            var inputUpper = input.Any(char.IsUpper);
            var inputLower = input.Any(char.IsLower);
            var inputDigit = input.Any(char.IsDigit);
            var inputSpecial = input.Any(c => @"!@#$%^&*_+".Contains(c));

            if (!inputUpper)
            {
                return new ValidationResult(false, "Пароль должен содержать хотя бы одну Заглавную букву");
            }
            if (!inputLower)
            {
                return new ValidationResult(false, "Пароль должен содержать хоты бы одну Строчную букву");
            }
            if (!inputDigit)
            {
                return new ValidationResult(false, "Пароль должен содержать хоты бы одну Цифру");
            }
            if (!inputSpecial)
            {
                return new ValidationResult(false, "Пароль должен содержать хоты бы один спецсимвол");
            }


            return ValidationResult.ValidResult;
        }

    }
}
