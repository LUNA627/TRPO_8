using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPO_8.Validation
{
    class IsOnlyCharsRule :ValidationRule
    {
        public override ValidationResult Validate (object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (!input.All(c => char.IsLetter(c) || c == ' ' || c == '-'))
            {
                return new ValidationResult(false, "Только буквы, пробелы и дефисы");
            }

            return ValidationResult.ValidResult;
        }
    }
}
