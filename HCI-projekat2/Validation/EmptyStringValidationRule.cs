using System.Globalization;
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
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Morate uneti vrednost.");
            }else
            {
                return new ValidationResult(true, null);
            }

        }
    }
}
