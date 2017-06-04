using System.Globalization;
using System.Windows.Controls;

namespace HCI_projekat2.Validation
{
    class ResourceIDValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string tmp = value as string;
            if (MainWindow.Resursi.ContainsKey(tmp))
            {
                System.Media.SystemSounds.Exclamation.Play();
                return new ValidationResult(false, "Resurs sa tim ID vec postoji.");
            }else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
