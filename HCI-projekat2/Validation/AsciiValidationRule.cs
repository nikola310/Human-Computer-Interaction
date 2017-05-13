using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    class AsciiValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string tmp = value as string;
            foreach(char c in tmp)
            {
                if (c > 255)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    return new ValidationResult(false, "Morate uneti ASCII karakter.");
                }
            }
            return new ValidationResult(true, null);
        }
    }
}
