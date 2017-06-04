using System.Globalization;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    class LabelIDValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string tmp = value as string;
            if (MainWindow.Etikete.ContainsKey(tmp))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Etiketa sa tim ID već postoji.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
