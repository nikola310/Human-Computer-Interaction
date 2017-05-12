using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    class EmptyStringValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string tmp = value as string;
            if (string.IsNullOrWhiteSpace(tmp))
            {
                return new ValidationResult(false, "Morate uneti vrednost.");
            }else
            {
                return new ValidationResult(true, null);
            }

        }
    }
}
