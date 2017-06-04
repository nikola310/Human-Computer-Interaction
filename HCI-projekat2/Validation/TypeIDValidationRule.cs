using System.Globalization;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    class TypeIDValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string tmp = value as string;
            if (MainWindow.Tipovi.ContainsKey(tmp))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Tip sa tim ID već postoji.");
            }else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
